using UnityEngine;

namespace Orca
{
    public class ActorHitPoint
    {
        public int Hp { get; private set; }

        private int MaxHp { get; set; }

        public ActorHitPoint(int currentHp, int maxHp)
        {
            Hp = currentHp;
            MaxHp = maxHp;
        }
        public ActorHitPoint(int hp)
        {
            MaxHp = Hp = hp;
        }

        public void Damage(int damage)
        {
            Hp -= damage;

            Hp = Mathf.Max(Hp, 0);
        }

        public void Recovery(int recovery)
        {
            Hp += recovery;

            Hp = Mathf.Min(Hp, MaxHp);
        }

        public bool IsAlive => Hp > 0;
    }
}