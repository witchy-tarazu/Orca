using UnityEngine;

namespace Orca
{
    public enum BattleType
    {
        Single,
        Versus,
    }

    public class BattleController : MonoBehaviour
    {
        private BattleType BattleType { get; set; }
        private ControllerState State { get; set; }

        private BattleSystem BattleSystem { get; set; }
        private BattleSystemFactory BattleSystemFactory { get; set; }

        private BattleInputContainer BattleInput { get; set; }
        private CustomInputContainer CustomInput { get; set; }

        public void Setup(MemoryDatabase database)
        {
            BattleSystemFactory = new(database);
            Shutdown();
        }

        public void PrepareEnemyBattle(
            int stageId,
            int level,
            BattleHeroData heroData,
            BattleResultCallbackContainer resultCallbackContainer)
        {
            BattleType = BattleType.Single;
            BattleSystem = BattleSystemFactory.CreateEnemyBattle(stageId, level, heroData, resultCallbackContainer);
        }

        public void PrepareVersusBattle(
            int stageId,
            BattleHeroData leftHeroData,
            BattleHeroData rightHeroData,
            BattleResultCallbackContainer resultCallbackContainer)
        {
            BattleType = BattleType.Versus;
            BattleSystem = BattleSystemFactory.CreateVersusBattle(stageId, leftHeroData, rightHeroData, resultCallbackContainer);
        }

        public void Activate()
        {
            State = ControllerState.Active;
        }

        public void Pause()
        {
            State = ControllerState.Pause;
        }

        public void Resume()
        {
            State = ControllerState.Active;
        }

        public void Shutdown()
        {
            State = ControllerState.Inactive;
        }

        private void Update()
        {
            if (State == ControllerState.Inactive || State == ControllerState.Pause)
            {
                return;
            }

            BattleSystem.Update();
        }

        private void LateUpdate()
        {
            if (State == ControllerState.Inactive)
            {
                return;
            }

            if (BattleInput.BattleCommand == BattleCommand.Pause
                && BattleType == BattleType.Single)
            {
                if (State == ControllerState.Pause)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
                return;
            }

            BattleInput.Reset();
            CustomInput.Reset();
        }
    }
}