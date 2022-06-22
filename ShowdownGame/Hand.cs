using System.Collections.Generic;

namespace ShowdownGame
{
    public class Hand
    {
        public readonly List<Card> Cards;

        public Hand(List<Card> defaultCards = null)
        {
            if (defaultCards == null)
            {
                Cards = new List<Card>();
            }
            else
            {
                Cards = new List<Card>(defaultCards);
            }
        }


        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}