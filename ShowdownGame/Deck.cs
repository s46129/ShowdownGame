using System;
using System.Collections.Generic;
using System.Linq;
using ShowdownGame;

internal class Deck
{
    public List<Card> Cards;

    public Deck()
    {
        Cards = new List<Card>();

        foreach (Rank rank in Enum.GetValues(typeof(Rank)))
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                Cards.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        Random random = new Random();
        Cards = Cards.OrderBy(_ => random.Next()).ToList();
    }

    public Card DrawCard()
    {
        Card draw = new Card(Cards[0].Suit, Cards[0].Rank);
        Cards.RemoveAt(0);
        return draw;
    }
}