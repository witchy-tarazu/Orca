using UnityEngine;

namespace Orca
{
    public class ActorHitPoint
    {
        public int Hp { get; private set; }

        public ActorHitPoint(int hp)
        {
            Hp = hp;
        }

        public void Damage(int damage)
        {
            Hp -= damage;

            Hp = Mathf.Max(Hp, 0);
        }

        public bool IsAlive() => Hp > 0;
    }
}