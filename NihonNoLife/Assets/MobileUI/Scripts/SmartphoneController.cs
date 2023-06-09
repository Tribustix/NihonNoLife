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
    [SerializeField] int startHours;
    [SerializeField] int startMinutes;
    [SerializeField] TMP_Text hoursTextUI;
    [SerializeField] TMP_Text minutesTextUI;


    private void Start()
    {
        hoursTextUI.text = startHours.ToString("0");
        minutesTextUI.text = startMinutes.ToString("0");

        BatteryLevelSlider(batteryStartValue);
        batteryLevelSlider.value = batteryStartValue;
    }

    public void BatteryLevelSlider(float batteryLevel)
    {
        batteryPercTextValue.text = batteryLevel.ToString("0");
    }
}
