using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppButton : MonoBehaviour
{
    public string appName;

    public TMP_Text title;
    
    public void ChangeTitle()
    {
        title.SetText(appName);
    }
}
