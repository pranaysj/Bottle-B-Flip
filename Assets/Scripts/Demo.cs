using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour , IDataPersistence
{
    
    public int num = 0;



    private void Start()
    {
    }
    public void Sum()
    {
        num++;
        
    }

    public void LoadData(GameData data)
    {
        this.num = data.bottleId;
        Debug.Log(" L Num : "  + this.num);
    }

    public void SaveData(ref GameData data)
    {
        data.bottleId = this.num;
        Debug.Log(" L Num : "  + data.bottleId);
    }
}       
