using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Profile : MonoBehaviour
{
    public Sprite buttonImage; //store image from button
    public GameObject profile; //gameobject which i wanr to chang ethe image
    [SerializeField] Shop shop; //check the number of the gameobject which is pressed.

    public int id;
    public ProfileSaved saveID;
    //public Dictionary <int, Sprite> dicForBottle = new Dictionary<int, Sprite>();


    private void Start()
    {
        //shop = GetComponent<Shop>();
        //ChangeProfile();
    }

    public void ChangeProfile()
    {
        for (int i = 0; i < shop.purchasedBottle.Count; i++)
        {
            //Debug.Log(shop.purchasedBottle[i]);
            buttonImage = gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite;
            //Debug.Log(buttonImage);
            ExtractNumber(buttonImage.name);
            int sameID = shop.purchasedBottle[i];

            if (sameID == id || id == 0 /*for default bottle, set the fedault bottle sprite name 01,etc*/)
            {
                profile.GetComponent<UnityEngine.UI.Image>().sprite = buttonImage;
                //dicForBottle.Add(i, buttonImage);
            }
        }
    }


    public void ExtractNumber(string inputString)
    {
        inputString = buttonImage.name;

        MatchCollection match = Regex.Matches(inputString, @"\d+");

        foreach (Match m in match)
        {
            int result;

            if (int.TryParse(m.Value, out result))
            {
                id = result;
                saveID.profileid = result;
            }
        }
    }

}
