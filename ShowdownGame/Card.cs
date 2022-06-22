using System.Collections.Generic;

namespace ShowdownGame
{
    public class Card : IComparer<Card>
    {
        public readonly Suit Suit;
        public readonly Rank Rank;

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }


        public int Compare(Card x, Card y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            var rankComparison = x.Rank.CompareTo(y.Rank);
            if (rankComparison != 0) return rankComparison;
            return x.Suit.CompareTo(y.Suit);
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

    public enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade,
    }
}