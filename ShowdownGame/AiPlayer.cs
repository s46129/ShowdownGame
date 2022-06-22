using System;


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
        int index = new Random().Next(0, hand.Cards.Count);
        SelectedCard = hand.Cards[index];
    }
}