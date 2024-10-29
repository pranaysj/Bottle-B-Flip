using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
//using static UnityEditor.Progress;
using Unity.VisualScripting;

public class Shop : MonoBehaviour, IDataPersistence
{

    GameObject itemTemplete;
    GameObject tempGameobject;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] Sprite defaultBottle;


    [Serializable] class ShopItem
    {
        public Sprite image;
        public int amount;
        public bool isPurchesd = false;
    }

    [SerializeField] List <ShopItem> ShopItemList;
    [SerializeField] public List<GameObject> InstantiateGameObject;
    [SerializeField] public List<int> purchasedBottle;
    [SerializeField] List<int> remainingBottle;

    public int bottleButtonID = 0;

    public void BottleSelOrCreate()
    {

        itemTemplete = ShopScrollView.GetChild(0).gameObject;
        int ShopItemLength = ShopItemList.Count;

        for (int i = 0; i < ShopItemLength; i++)
        {
            tempGameobject = Instantiate(itemTemplete, ShopScrollView);

            if (purchasedBottle.Contains(i))
            {
                tempGameobject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = ShopItemList[i].image;
                ShopItemList[i].isPurchesd = true;
            }
            else
            {
                remainingBottle.Add(i);
            }

            InstantiateGameObject.Add(tempGameobject);
            
        }
        itemTemplete.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = defaultBottle;
        
    }

    public void RandomBottleSelect()
    {
        if (remainingBottle.Count > 0)
        {
            int ShopItemLength = ShopItemList.Count;
            System.Random rand = new System.Random();

            int remainingIndexNumber = rand.Next(remainingBottle.Count);

            int selectRandomBottle = remainingBottle[remainingIndexNumber];

            //Debug.Log(" selectRandomBottle : " + selectRandomBottle + " remainingBottle.Count : " + remainingBottle.Count + " remainingBottle list : " + string.Join(", ", remainingBottle.ToArray()));

            for (int i = 0; i < remainingBottle.Count ; i++)
            {
                //Debug.Log(" i : " + i + " remainingBottle[i] : " + remainingBottle[i]);

                if (remainingBottle[i] == selectRandomBottle )
                {
                    //Debug.Log("Enter");

                    if (Coins.instance.HasEnoughCoins(ShopItemList[i].amount))
                    {
                        //Debug.Log("Enter 2X");
                        Coins.instance.UseCoins(ShopItemList[i].amount);

                        //InstantiateGameObject[selectRandomBottle].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = ShopItemList[i].image;
                        InstantiateGameObject[selectRandomBottle].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = ShopItemList[selectRandomBottle].image;
                        ShopItemList[i].isPurchesd = true;


                        purchasedBottle.Add(selectRandomBottle);
                        remainingBottle.Remove(selectRandomBottle);
                    }

                }
                
            }

        }

        
    }

    public void LoadData(GameData data)
    {
        //Check the purchasedBottle list contains , if true then do not add, if false then add it. iterate using loop like foreach
        purchasedBottle = new List<int>();

        remainingBottle = new List<int>();

        this.purchasedBottle = data.bottlePurchased;

        BottleSelOrCreate();

        
    }

    public void SaveData(ref GameData data)
    {
        if (purchasedBottle.Count != 0)
        {
            data.bottlePurchased = this.purchasedBottle.Distinct().ToList();

        }
    }
}
