using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Showdown
{
    private List<Player> _players = new List<Player>();
    private Deck _deck;

    private int _round = 1;

    public void Start()
    {
        _players = new List<Player>();
        HumanPlayer humanPlayer = new HumanPlayer();
        humanPlayer.NameHimSelf();
        AddPlayer(humanPlayer);
        for (int i = 1; i < 4; i++)
        {
            AddPlayer(new AiPlayer($"P{i + 1}"));
        }

        _deck = new Deck();
        _deck.Shuffle();

        int drawIndex = 0;
        while (_deck.Cards.Count > 0)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].hand.AddCard(_deck.DrawCard());
            }
        }

        Console.WriteLine("\n **** Start Game ****\n");

        for (int i = 0; i < 52 / _players.Count; i++)
        {
            for (int j = 0; j < _players.Count; j++)
            {
                TakesATurn(_players[j]);
            }

            Console.WriteLine("\n **** Show Down ****\n");

            ShowDown();

            CleanPlayersSelect();
        }
    }

    private void CleanPlayersSelect()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            _players[i].CleanCurrentSelect();
        }
    }


    private void TakesATurn(Player currentPlayer)
    {
        currentPlayer.SelectCard();
    }

    public void ShowDown()
    {
        List<RoundSelect> roundSelects = new List<RoundSelect>();
        foreach (var player in _players)
        {
            roundSelects.Add(new RoundSelect(player, player.Show()));
        }

        roundSelects.Sort(delegate(RoundSelect x, RoundSelect y)
        {
            if (x._card == null && y._card == null)
            {
                return 0;
            }
            else if (x._card == null)
            {
                return -1;
            }
            else if (y._card == null)
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

    public void GameOver()
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
        public Card _card;

        public RoundSelect(Player player, Card card)
        {
            Player = player;
            _card = card;
        }

        public int Compare(RoundSelect x, RoundSelect y)
        {
            return x._card.Compare(x._card, y._card);
        }
    }
}