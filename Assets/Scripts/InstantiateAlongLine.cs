//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
public class InstantiateAlongLine : Level
{
    public GameObject[] prefab;
    public float number;
    //public Transform start;
    public float totalDiatnace = 0;
    public float prefabsize = 0;
    public float offset = 2;
    public GameObject finishObject;
    public Vector3 finishposition;

    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            var element = prefab[Random.Range(0, prefab.Length)];
            var position = new Vector3(prefabsize, 0, 0);


            Instantiate(element, position, element.transform.rotation);
            


            prefabsize = element.GetComponent<BoxCollider>().size.x + totalDiatnace + offset;
            totalDiatnace = prefabsize;

        }

        finishposition = new Vector3(totalDiatnace + offset , 0, 0);
        Instantiate(finishObject, finishposition, Quaternion.identity);
        
    }

}
