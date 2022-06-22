public class ExchangeHands
{
    private int _countDown = 3;

    private Player _usedPlayer;
    private Player _targetPlayer;

    public ExchangeHands(Player usedPlayer, Player targetPlayer)
    {
        _usedPlayer = usedPlayer;
        _targetPlayer = targetPlayer;

        Change(_usedPlayer, _targetPlayer);
    }

    public void OnEndOfRound()
    {
        _countDown--;
        if (_countDown <= 0)
        {
            Change(_targetPlayer, _usedPlayer);
        }
    }

    void Change(Player from, Player to)
    {
        Hand fromHand = from.hand;
        Hand toHand = to.hand;
        from.hand = toHand;
        to.hand = fromHand;
    }
}
