using System;
using System.Collections.Generic;
using System.Linq;

namespace ShowdownGame
{
    public class Showdown
    {
        private readonly List<Player> _players;
        private int _round = 1;

        public Showdown()
        {
            _players = new List<Player>();
            HumanPlayer humanPlayer = new HumanPlayer();
            humanPlayer.NameHimSelf();
            AddPlayer(humanPlayer);
            for (int i = 1; i < 4; i++)
            {
                AddPlayer(new AiPlayer($"P{i + 1}"));
            }

            var deck = new Deck();
            deck.Shuffle();

            while (deck.Cards.Count > 0)
            {
                foreach (var player in _players)
                {
                    player.hand.AddCard(deck.DrawCard());
                }
            }
        }

        public void Start()
        {
            Console.WriteLine("\n **** Start Game ****\n");

            for (int i = 0; i < 52 / _players.Count; i++)
            {
                for (int j = 0; j < _players.Count; j++)
                {
                    TakesATurn(_players[j]);
                }

                OnRoundEnd();
            }
        }

        private void OnRoundEnd()
        {
            ShowDown();
            PlayersOnRoundEnd();


            _round++;
            if (_round > 13)
            {
                GameOver();
            }
            else
            {
                Console.WriteLine($"\n***** Round {_round} *****");
            }
        }

        private void PlayersOnRoundEnd()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].CleanCurrentSelect();

                if (_players[i].ExchangePrivilege != null)
                {
                    _players[i].ExchangePrivilege.OnEndOfRound();
                }
            }
        }


        private void TakesATurn(Player currentPlayer)
        {
            CheckUseExchange(currentPlayer);

            if (currentPlayer.hand.Cards.Count > 0)
            {
                currentPlayer.SelectCard();
            }
        }

        private void CheckUseExchange(Player currentPlayer)
        {
            if (currentPlayer.UsedExChange == false && currentPlayer.AskUseExchangeHand())
            {
                List<Player> choice = new List<Player>(_players);
                choice.Remove(currentPlayer);
                currentPlayer.ExChange(currentPlayer.SelectPlayer(choice));
            }
        }

        private void ShowDown()
        {
            Console.WriteLine("\n **** Show Down ****\n");
            List<RoundSelect> roundSelects = new List<RoundSelect>();
            foreach (var player in _players)
            {
                if (player.Show() != null)
                {
                    Console.WriteLine($"{player.Name()} show {player.Show().Suit} {player.Show().Rank}");
                    roundSelects.Add(new RoundSelect(player, player.Show()));
                }
            }

            roundSelects.Sort(delegate(RoundSelect x, RoundSelect y)
            {
                if (x.Card == null && y.Card == null)
                {
                    return 0;
                }
                else if (x.Card == null)
                {
                    return -1;
                }
                else if (y.Card == null)
                {
                    return 1;
                }
                else
                {
                    return x.Compare(x, y);
                }
            });


            Console.WriteLine($"Current Winner : {roundSelects[0].Player.Name()}");

            roundSelects[0].Player.AddPoint();
        }

        private void GameOver()
        {
            ShowWinner();
        }

        public Player ShowWinner()
        {
            Console.WriteLine("\n ***** Game Over *****");
            Console.WriteLine("Result:");
            List<Player> order = _players.OrderByDescending(player => player.GetPoint()).ToList();

            for (int i = 0; i < order.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {order[i].Name()} : {order[i].GetPoint()}");
            }

            Console.WriteLine("============\n");
            Console.WriteLine($"{order[0].Name()} is winner.");
            Console.WriteLine("\n============");
            return order[0];
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
            Console.WriteLine($"Add player {player.Name()}");
        }

        private class RoundSelect : IComparer<RoundSelect>
        {
            public Player Player { get; }
            public readonly Card Card;

            public RoundSelect(Player player, Card card)
            {
                Player = player;
                Card = card;
            }

            public int Compare(RoundSelect x, RoundSelect y)
            {
                if (y == null)
                    return -1;
                if (x == null)
                    return 1;

                return y.Card.Compare(y.Card, x.Card);
            }
        }
    }
}