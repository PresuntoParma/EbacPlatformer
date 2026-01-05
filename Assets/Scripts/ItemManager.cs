using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public TextMeshProUGUI textCoins;

    public static ItemManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

            Reset();
    }

    private void Start()
    {
        textCoins.text = "X " + coins;
    }

    public void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int ammount = 1)
    {
        coins += ammount;
        textCoins.text = "X " + coins;
    }


}
