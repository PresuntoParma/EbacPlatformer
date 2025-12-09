using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int ammount = 1)
    {
        coins += ammount;
    }


}
