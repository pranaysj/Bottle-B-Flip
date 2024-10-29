using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    public int level;
    public int coins;
    public List<int> bottlePurchased;
    public bool isPurchased;
    public int bottleId;

    public GameData()
    {
        this.level = 0;
        this.coins = 0;
        this.bottlePurchased = new List<int>();
        this.isPurchased = false;
        this.bottleId = 0;
    }
}
