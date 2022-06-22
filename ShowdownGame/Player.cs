using System;

public abstract class Player
{
    protected string _name;
    private int _point;
    public Hand hand;
    private ExchangeHands _exchangePrivilege;
    public Card SelectedCard;

    public string Name()
    {
        return _name;
    }

    public Player(string name = "")
    {
        _name = name;
        _point = 0;
        hand = new Hand();
        _exchangePrivilege = null;
    }

    public abstract void NameHimSelf(string set = null);

    public void ExChange(Player to)
    {
        if (_exchangePrivilege != null)
        {
            return;
        }

        _exchangePrivilege = new ExchangeHands(this, to);
    }

    public Card Show()
    {
        Console.WriteLine($"{_name} show {SelectedCard._suit} {SelectedCard._rank}");
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
        hand.Cards.Remove(SelectedCard);
        SelectedCard = null;
    }
}