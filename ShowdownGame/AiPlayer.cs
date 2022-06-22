using System;
using System.Collections.Generic;

namespace ShowdownGame
{
    public class AiPlayer : Player
    {
        public AiPlayer(string name = null) : base(name)
        {
            _name = name;
        }


        public override void NameHimSelf(string set)
        {
            _name = set;
        }

        public override void SelectCard()
        {
            int selectId = new Random().Next(0, hand.Cards.Count);
            SelectedCard = new Card(hand.Cards[selectId].Suit, hand.Cards[selectId].Rank);
            hand.Cards.RemoveAt(selectId);
        }

        public override bool AskUseExchangeHand()
        {
            return new Random().Next(-2, 2) > 0;
        }

        public override Player SelectPlayer(List<Player> value)
        {
            return value[new Random().Next(0, value.Count)];
        }
    }
}