using UnityEngine;

namespace Orca
{
    public class ActorHp
    {
        public int Hp { get; private set; }

        public ActorHp(int hp)
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