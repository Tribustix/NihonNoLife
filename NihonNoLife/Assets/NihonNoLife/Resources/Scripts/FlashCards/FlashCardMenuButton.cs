using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashCardMenuButton : MonoBehaviour
{
    public int index;
    private GameObject flashCardSystem;
  
    public void ActivateFlashCardSystem()
    {
        flashCardSystem = GameObject.FindGameObjectWithTag("ExternalApps");
        flashCardSystem.transform.GetChild(0).gameObject.SetActive(true);
        flashCardSystem.GetComponentInChildren<FlashCardManager>().fileSelected = index;
    }
}
