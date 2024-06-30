using System.Collections.Generic;

namespace Orca
{
    public class ActorCard
    {
        public MasterCard CurrentCard { get; private set; }

        private Queue<MasterCard> CardQueue { get; }

        public bool HasCard() => CardQueue.Count > 0;

        public ActorCard() { CardQueue = new Queue<MasterCard>(); }

        public void Set(List<MasterCard> cards)
        {
            if (cards.Count == 0)
            {
                // キューのリセットもしない
                return;
            }

            CurrentCard = cards[0];
            foreach (MasterCard card in cards) { CardQueue.Enqueue(card); }
        }

        public MasterCard Use()
        {
            var card = CardQueue.Dequeue();
            if (HasCard())
            {
                CurrentCard = CardQueue.Peek();
            }
            else
            {
                CurrentCard = null;
            }
            return card;
        }
    }
}