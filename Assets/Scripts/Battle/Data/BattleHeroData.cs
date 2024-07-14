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

        public List<MasterCard> Cards { get; }

        public PanelPosition StartPosition { get; private set; }

        public BattleHeroData(
            int hp,
            int maxHp,
            int speed,
            BattleInputContainer inputContainer,
            MasterCard attackMaster,
            List<MasterCard> cards)
        {
            Hp = hp;
            MaxHp = maxHp;
            Speed = speed;
            InputContainer = inputContainer;
            AttackMaster = attackMaster;
            Cards = cards;
        }

        public void SetStartPosition(PanelPosition panelPosition)
        {
            StartPosition = panelPosition;
        }
    }
}