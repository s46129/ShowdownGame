using System;

namespace ShowdownGame
{
    public class ExchangeHands
    {
        private int _countDown = 3;

        private readonly Player _usedPlayer;
        private readonly Player _targetPlayer;

        public ExchangeHands(Player usedPlayer, Player targetPlayer)
        {
            _usedPlayer = usedPlayer;
            _targetPlayer = targetPlayer;

            Change(_usedPlayer, _targetPlayer);
        }

        public void OnEndOfRound()
        {
            _countDown--;
            Console.WriteLine($"{_usedPlayer.Name()} countDown {_countDown}");
            if (_countDown <= 0)
            {
                Console.WriteLine("Change Back:");
                Change(_usedPlayer, _targetPlayer);
                _usedPlayer.ExchangePrivilege = null;
            }

        }

        void Change(Player from, Player to)
        {
            Console.WriteLine($"{from.Name()} change hand cards with {to.Name()}");
            Hand fromHand = new Hand(from.hand.Cards);
            Hand toHand = new Hand(to.hand.Cards);
            from.hand = toHand;
            to.hand = fromHand;
        }
    }
}