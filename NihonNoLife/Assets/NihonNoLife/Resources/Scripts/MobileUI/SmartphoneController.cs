using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SmartphoneController : MonoBehaviour
{
    [Header("Battery Level")]
    [SerializeField] float batteryStartValue;
    [SerializeField] Slider batteryLevelSlider;
    [SerializeField] TMP_Text batteryPercTextValue;

    [Header("Mobile Phone Time")]
    [SerializeField] TMP_Text hourTextUI;

    [Header("Apps")]
    [SerializeField] GameObject[] apps;

    [Header("Mobile UI Title")]
    public TMP_Text title;

    private void Start()
    {
        hourTextUI.text = DateTime.Now.ToString("hh:mm");

        BatteryLevelSlider(batteryStartValue);
        batteryLevelSlider.value = batteryStartValue;
    }

    public void BatteryLevelSlider(float batteryLevel)
    {
        batteryPercTextValue.text = batteryLevel.ToString("0") + " %";
    }

    public void CloseAllApps()
    {
        foreach(GameObject app in apps)
        {
            app.SetActive(false);
        }

        title.text = "MOBILE MENU";
    }
}
