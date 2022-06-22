using System;
using System.Collections.Generic;

namespace ShowdownGame
{
    public abstract class Player
    {
        protected string _name;
        private int _point;
        public Hand hand;
        public ExchangeHands ExchangePrivilege;
        public bool UsedExChange = false;
        protected Card SelectedCard;

        public string Name()
        {
            return _name;
        }

        public Player(string name = "")
        {
            _name = name;
            _point = 0;
            hand = new Hand();
            ExchangePrivilege = null;
        }

        public abstract void NameHimSelf(string set = null);

        public void ExChange(Player to)
        {
            if (UsedExChange)
            {
                return;
            }

            UsedExChange = true;
            ExchangePrivilege = new ExchangeHands(this, to);
        }

        public Card Show()
        {
            return SelectedCard;
        }

        public abstract void SelectCard();

        public int GetPoint()
        {
            return _point;
        }

        public void AddPoint()
        {
            _point++;
        }

        public void CleanCurrentSelect()
        {
            SelectedCard = null;
        }

        public abstract bool AskUseExchangeHand();

        public abstract Player SelectPlayer(List<Player> value);
    }
}