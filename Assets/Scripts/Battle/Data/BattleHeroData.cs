using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class BattleHeroData
    {
        public int Hp { get; }
        public int MaxHp { get; }
        public int Speed { get; }

        public BattleInputContainer InputContainer { get; }

        public MasterCard AttackMaster { get; }

        public PanelPosition StartPosition { get; private set; }

        public BattleHeroData(
            int hp,
            int maxHp,
            int speed,
            BattleInputContainer inputContainer,
            MasterCard attackMaster)
        {
            Hp = hp;
            MaxHp = maxHp;
            Speed = speed;
            InputContainer = inputContainer;
            AttackMaster = attackMaster;
        }

        public void SetStartPosition(PanelPosition panelPosition)
        {
            StartPosition = panelPosition;
        }
    }
}