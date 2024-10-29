using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        ScreenCapture.CaptureScreenshot("ss.png");
        Debug.Log("SS");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ScreenCapture.CaptureScreenshot("ss.png");
            Debug.Log("SS");
        }
    }
}
