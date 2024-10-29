using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ProfileSaved : MonoBehaviour, IDataPersistence
{
    public int profileid;
    public GameObject profileImage;

    [SerializeField] List<Sprite> bottleSprite;

    public BottleChange bottleChange;

    public void ProfileImage()
    {
        Debug.Log(" Button : " + this.profileid);
        
        profileImage.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = bottleSprite[profileid];

    }

    public void LoadData(GameData data)
    {
        this.profileid = data.bottleId;
        bottleChange.BottleMesh();
    }

    public void SaveData(ref GameData data)
    {
        data.bottleId = this.profileid;

    }

}
