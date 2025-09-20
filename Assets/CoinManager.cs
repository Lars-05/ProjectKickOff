using UnityEngine;

public static class CoinManager
{
    public static int coins = 0;

    public static void AddCoins(int amount)
    {
        coins += amount;
    }

    public static void RemoveCoins(int amount)
    {
        coins -= amount;
    }
}
