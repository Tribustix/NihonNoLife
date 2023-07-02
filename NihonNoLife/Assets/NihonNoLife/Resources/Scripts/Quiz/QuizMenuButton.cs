using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizMenuButton : MonoBehaviour
{
    public int index;
    private GameObject QuizSystem;
  
    public void ActivateQuizSystem()
    {
        QuizSystem = GameObject.FindGameObjectWithTag("ExternalApps");
        QuizSystem.transform.GetChild(1).gameObject.SetActive(true);
        QuizSystem.GetComponentInChildren<QuizManager>().fileSelected = index;
    }
}
