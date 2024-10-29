using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject playerPosition;
    //public GameObject finalPosition;
    public InstantiateAlongLine finishposition;

    public float progress;
    public Image progressImage;

    void Start()
    {
        progressImage = GetComponent<Image>();
        //finishposition = GetComponent<InstantiateAlongLine>();
    } 

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(finishposition.finishposition);
        progress = playerPosition.transform.position.x / finishposition.finishposition.x;
        progressImage.fillAmount = progress;
    }
}
