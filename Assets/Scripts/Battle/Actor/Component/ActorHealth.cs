using System;
using System.Collections.Generic;

namespace Orca
{
    public class ActorHealth
    {
        public ActorSide Side { get; private set; }
        private ActorStatus Status { get; set; }
        private ActorHitPoint HitPoint { get; set; }

        private HashSet<int> ReceivedSerial { get; set; }

        public bool IsAlive => HitPoint.IsAlive();

        public ActorHealth(ActorSide side, int maxHp)
        {
            Side = side;

            Status = new(OnApplyAbnormalState);
            HitPoint = new(maxHp);

            ReceivedSerial = new();
        }

        public ActorHealth(ActorSide side, int currentHp, int maxHp)
        {
            Side = side;

            Status = new(OnApplyAbnormalState);
            HitPoint = new(currentHp, maxHp);

            ReceivedSerial = new();
        }

        public int GetHp() => HitPoint.Hp;

        public void Damage(
            int damage,
            InfluencePenetrationType penetrationType,
            ActorHealth owner,
            Action<ActorHealth> onDamage,
            int serial)
        {
            if (ReceivedSerial.Contains(serial)) { return; }
            ReceivedSerial.Add(serial);

            DamageCore(damage, penetrationType, owner, onDamage);
        }

        public void DazzleDamage()
        {
            DamageCore(BattleDefine.DazzleDamage, InfluencePenetrationType.None, this, null);
        }

        private void DamageCore(
            int damage,
            InfluencePenetrationType penetrationType,
            ActorHealth owner,
            Action<ActorHealth> onDamage)
        {
            // ���G�E����̏���
            if (Status.IsState(ActorState.Invincible)
                && penetrationType != InfluencePenetrationType.Invincible
                && penetrationType != InfluencePenetrationType.Whole)
            {
                // �_���[�W�͎󂯂Ȃ�
                return;
            }

            var ownerStatus = owner.Status;

            // �Èł̏���
            if (ownerStatus.IsState(ActorState.Darkness)
                && !ownerStatus.HasStack(ActorState.Critical))
            {
                // �N���e�B�J���ȊO�̏ꍇ�̓_���[�W�͎󂯂Ȃ�
                return;
            }

            int defenceStack = Status.GetStackValue(ActorState.DefenceBuff);
            int attackStack = ownerStatus.GetStackValue(ActorState.AttackBuff);
            if (ownerStatus.HasStack(ActorState.Critical))
            {
                // �N���e�B�J���͖h��𖳎�����
                defenceStack = 0;
                damage *= 2;
                ownerStatus.ConsumeStack(ActorState.Critical, 1);
            }
            damage *= (100 + attackStack - defenceStack) / 100;

            // �o���A�̏���
            if (Status.HasStack(ActorState.Barrier)
                && penetrationType != InfluencePenetrationType.Barrier
                && penetrationType != InfluencePenetrationType.Whole)
            {
                int stackValue = Status.GetStackValue(ActorState.Barrier);
                Status.ConsumeStack(ActorState.Barrier, damage);

                damage -= stackValue;

                // �o���A�Ń_���[�W�����ׂČy�����ꂽ�ꍇ�ɂ͂����ŏI��
                if (damage <= 0) { return; }
            }

            HitPoint.Damage(damage);

            if (ownerStatus.HasStack(ActorState.Drain))
            {
                owner.HitPoint.Recovery(damage);
                ownerStatus.ConsumeStack(ActorState.Drain, 1);
            }

            onDamage?.Invoke(this);
        }

        public void Recovery(int recovery, int serial)
        {
            if (ReceivedSerial.Contains(serial)) { return; }
            ReceivedSerial.Add(serial);

            HitPoint.Recovery(recovery);
        }

        public void AddStack(
            ActorState stackState,
            int value,
            ActorHealth owner,
            InfluencePenetrationType penetrationType,
            int serial)
        {
            if (ReceivedSerial.Contains(serial)) { return; }
            ReceivedSerial.Add(serial);

            if (value > 0)
            {
                // �L�����ʂ͂��ׂēK�p����
                Status.AddStack(stackState, value);
                return;
            }

            // �s�����ʂ͂ӂ邢�ɂ�����
            if (!CanBadStateAdapt(penetrationType, owner))
            {
                return;
            }

            Status.AddStack(stackState, value);
        }

        public void RemoveStack(ActorState stackState, int serial)
        {
            if (ReceivedSerial.Contains(serial)) { return; }
            ReceivedSerial.Add(serial);

            Status.RemoveStack(stackState);
        }

        public void MakeState(
            ActorState abnormalState,
            int duration,
            ActorHealth owner,
            InfluencePenetrationType penetrationType,
            int serial)
        {
            if (ReceivedSerial.Contains(serial)) { return; }
            ReceivedSerial.Add(serial);

            // �s�����ʂ͂ӂ邢�ɂ�����
            switch (abnormalState)
            {
                case ActorState.Poison:
                case ActorState.Darkness:
                case ActorState.Dazzle:
                case ActorState.Stan:
                    if (!CanBadStateAdapt(penetrationType, owner))
                    {
                        return;
                    }
                    break;
            }

            Status.MakeState(abnormalState, duration);
        }

        public bool IsDisableAction()
        {
            return Status.IsState(ActorState.Stan) || !IsAlive;
        }

        public bool IsDazzle()
        {
            return Status.IsState(ActorState.Dazzle);
        }

        public void Update()
        {
            Status.Update();
        }

        private void OnApplyAbnormalState(ActorState state)
        {
            // ��Ԉُ�ɂ����ʂ̓o���A�△�G���ђʂ���
            switch (state)
            {
                case ActorState.Regeneration:
                    HitPoint.Recovery(BattleDefine.RegenerationValue);
                    break;
                case ActorState.Poison:
                    HitPoint.Damage(BattleDefine.PoisonSlipDamage);
                    break;
            }
        }

        private bool CanBadStateAdapt(InfluencePenetrationType penetrationType, ActorHealth owner)
        {
            if (owner.Status.IsState(ActorState.Darkness)) { return false; }

            switch (penetrationType)
            {
                case InfluencePenetrationType.None:
                    if (Status.HasStack(ActorState.Barrier)
                        || Status.IsState(ActorState.Invincible))
                    { return false; }
                    break;
                case InfluencePenetrationType.Barrier:
                    if (Status.IsState(ActorState.Invincible)) { return false; }
                    break;
                case InfluencePenetrationType.Invincible:
                    if (Status.HasStack(ActorState.Barrier)) { return false; }
                    break;
            }

            return true;
        }
    }
}