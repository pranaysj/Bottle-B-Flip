using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour,IDataPersistence
{
    #region Singleton Coins

    public static Coins instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);

        }
    }
    #endregion

    public int coins;
    public List<TMP_Text> coinText;

    private void Start()
    {
        for (int i = 0; i < coinText.Count; i++)
        {
            coinText[i].text = coins.ToString();
        }

    }


    public void UseCoins(int amount)
    {
        coins = coins - amount;
        CointText();
    }

    public bool HasEnoughCoins(int amount)
    {
        return (coins >=  amount);
    }

    public void CointText()
    {
        for (int i = 0; i < coinText.Count; i++)
        {
            coinText[i].text = coins.ToString();
        }
    }

    public void LoadData(GameData data)
    {
        this.coins = data.coins;

    }

    public void SaveData(ref GameData data)
    {
        data.coins = this.coins;
    }
}
