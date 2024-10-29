using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAdsButton : MonoBehaviour
{
    public int coinCollected;

    public void PlayAds()
    {

        InterstitialAds.Instance.ShowAd();
        coinCollected = coinCollected + 100;
        Coins.instance.coins += coinCollected;
        Coins.instance.CointText();
    }
}
