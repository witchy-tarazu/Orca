using System.Collections.Generic;

namespace Orca
{
    public class ActorCard
    {
        private BattleCard currentCard { get; set; }

        private Queue<BattleCard> cardQueue { get; set; }

        public BattleCard GetCurrentInfo() => currentCard;

        public BattleCard Use() => cardQueue.Dequeue();

        public ActorCard() { cardQueue = new Queue<BattleCard>(); }

        public void Set(List<BattleCard> cards)
        {
            if (cards.Count == 0)
            {
                // キューのリセットもしない
                return;
            }

            currentCard = cards[0];
            foreach (BattleCard card in cards) { cardQueue.Enqueue(card); }
        }
    }
}