using System.Collections.Generic;

namespace Orca
{
    public class ActorCard
    {
        private MasterCard currentCard { get; set; }

        private Queue<MasterCard> cardQueue { get; set; }

        public MasterCard GetCurrentInfo() => currentCard;

        public MasterCard Use() => cardQueue.Dequeue();

        public ActorCard() { cardQueue = new Queue<MasterCard>(); }

        public void Set(List<MasterCard> cards)
        {
            if (cards.Count == 0)
            {
                // キューのリセットもしない
                return;
            }

            currentCard = cards[0];
            foreach (MasterCard card in cards) { cardQueue.Enqueue(card); }
        }
    }
}