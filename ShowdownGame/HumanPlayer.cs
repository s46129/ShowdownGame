using System;
using System.Collections.Generic;

namespace ShowdownGame
{
    public class HumanPlayer : Player
    {
        public override void NameHimSelf(string set = null)
        {
            Console.WriteLine("Set Player Name:");
            _name = Console.ReadLine();
        }

        public override void SelectCard()
        {
            Console.WriteLine($"Turn {_name} to select Card (Input 0~{hand.Cards.Count - 1}): ");
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                Console.WriteLine($"{i}.{hand.Cards[i].Suit} {hand.Cards[i].Rank} ");
            }

            int selectId = (int) Console.Read() - 48;
            // selectId = Math.Clamp(selectId,0, hand.Cards.Count); => 找不到＠＠？！
            if (selectId >= hand.Cards.Count)
            {
                selectId = hand.Cards.Count - 1;
            }
            else if (selectId < 0)
            {
                selectId = 0;
            }

            Console.WriteLine($"\nSelected: {selectId}. {hand.Cards[selectId].Suit} {hand.Cards[selectId].Rank}");
            SelectedCard = new Card(hand.Cards[selectId].Suit, hand.Cards[selectId].Rank);
            hand.Cards.RemoveAt(selectId);
        }

        public override bool AskUseExchangeHand()
        {
            Console.WriteLine("Do you need use hand exchange (Only once)?(Y/N)");
            string useExchange = Console.ReadLine();
            return useExchange != null && useExchange.Equals("Y");
        }

        public override Player SelectPlayer(List<Player> value)
        {
            Console.WriteLine($"Select Player ID (0~{value.Count}) :");
            for (int i = 0; i < value.Count; i++)
            {
                Console.WriteLine($"{i}. {value[i].Name()} ");
            }

            int selectedId = Console.Read() - 48;

            //又是Clamp無法用～～～
            if (selectedId >= value.Count)
            {
                selectedId = value.Count - 1;
            }
            else if (selectedId < 0)
            {
                selectedId = 0;
            }

            return value[selectedId];
        }
    }
}