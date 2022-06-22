using System;

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
            Console.WriteLine($"{i}.{hand.Cards[i]._suit} {hand.Cards[i]._rank} ");
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

        Console.WriteLine($"\nSelected: {selectId}. {hand.Cards[selectId]._suit} {hand.Cards[selectId]._rank}");
        SelectedCard = hand.Cards[selectId];
    }
}