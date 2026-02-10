using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBadCoin : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins(-1);
    }

}
