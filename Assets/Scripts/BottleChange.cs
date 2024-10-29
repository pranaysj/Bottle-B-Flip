using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleChange : MonoBehaviour
{
    public List<GameObject> bottle;
    public ProfileSaved profileID;
    GameObject child;

    public void BottleMesh()
    {
        if (child != null)
        {
            Destroy (child);
        }
        for(int i = 0; i < bottle.Count; i++)
        {
            if (i == profileID.profileid)
            {
                child = Instantiate(bottle[i]);
                child.transform.parent = transform;
                child.transform.localPosition = Vector3.zero;
                child.transform.localRotation = Quaternion.identity;
                child.transform.localScale = Vector3.one;
            }
        }
    }
}
