using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using CandyCoded.HapticFeedback;

public class ButtonVibrationHandler : MonoBehaviour
{
    [SerializeField]
    private Button noADSbutton;
    [SerializeField]
    private Button selectBottle;
    [SerializeField]
    private Button startGameButton;
    [SerializeField]
    private Button settingButton;
    [SerializeField]
    private Button finishPanelButton;
    



    private void OnEnable()
    {
        noADSbutton.onClick.AddListener(MediumVibration);
        selectBottle.onClick.AddListener(MediumVibration);
        settingButton.onClick.AddListener(MediumVibration);

        startGameButton.onClick.AddListener(HeavyFeedback);
        finishPanelButton.onClick.AddListener(HeavyFeedback);
    }

    private void OnDisable()
    {
        noADSbutton.onClick.RemoveListener(MediumVibration);
        selectBottle.onClick.RemoveListener(MediumVibration);
        settingButton.onClick.RemoveListener(MediumVibration);

        startGameButton.onClick.RemoveListener(HeavyFeedback);
        finishPanelButton.onClick.RemoveListener(HeavyFeedback);
    }

    

    private void LightVibration()
    {
        //Debug.Log("Light Vibration performed");
        HapticFeedback.LightFeedback();
    }

    private void MediumVibration()
    {
        //Debug.Log("Light Vibration performed");
        HapticFeedback.MediumFeedback();
    }

    private void HeavyFeedback()
    {
        //Debug.Log("Light Vibration performed");
        HapticFeedback.HeavyFeedback();
    }
}
