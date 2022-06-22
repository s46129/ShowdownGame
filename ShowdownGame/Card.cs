using System.Collections.Generic;

public class Card:IComparer<Card>
{
    public Suit _suit;
    public Rank _rank;

    public Card(Suit suit, Rank rank)
    {
        _suit = suit;
        _rank = rank;
    }



    public int Compare(Card x, Card y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        var rankComparison = x._rank.CompareTo(y._rank);
        if (rankComparison != 0) return rankComparison;
        return x._suit.CompareTo(y._suit);
    }
}


public enum Rank
{
    Two,
    Three,
    Fort,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    J,
    Q,
    K,
    A
}