using System.Collections.Generic;


public class Hand
{
    public List<Card> Cards;

    public Hand()
    {
        Cards = new List<Card>();
    }


    public void AddCard(Card card)
    {
        Cards.Add(card);
    }
}