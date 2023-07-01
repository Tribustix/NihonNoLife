using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashCardSlider: MonoBehaviour
{
    public GameObject scrollbar;

    private float scrollPostion = 0;
    private float[] position;
    private int positonIndex = 0;


    public void Next()
    {
        if(positonIndex < position.Length - 1)
        {
            positonIndex += 1;
            scrollPostion = position[positonIndex];
        }
    }

    public void Previous()
    {
        if (positonIndex > 0)
        {
            positonIndex -= 1;
            scrollPostion = position[positonIndex];
        }
    }

    private void Update()
    {
        position = new float[transform.childCount];

        float distance = 1f / (position.Length - 1f);

        for (int i = 0; i < position.Length; i++)
        {
            position[i] = distance * i;
        }

        if(Input.GetMouseButton(0))
        {
            scrollPostion = scrollbar.GetComponent<Scrollbar>().value;
        }else
        {
            for (int i = 0; i < position.Length; i++)
            {
                if(scrollPostion < position[i] + (distance / 2) && scrollPostion > position[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, position[i], 0.15f);
                }
            }
        }
    }

}

