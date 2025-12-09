using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int coins;


    public static ItemManager instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


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
