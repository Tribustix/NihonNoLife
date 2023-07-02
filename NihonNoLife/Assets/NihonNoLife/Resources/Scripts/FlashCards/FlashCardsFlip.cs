using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlashCardsFlip : MonoBehaviour
{

    public RectTransform r;
    public TMP_Text cardText;

    public string textEsp;
    public string textJap;

    private float flipTime = 0.5f;
    private int faceSide = 0; // 0 = front, 1 = back
    private int isShrinking = -1; // -1 = get smaller, 1 = get bigger 
    private bool isFlipping = false;
    private float distancePerTime;
    private float timeCount = 0;


    void Start()
    {
        distancePerTime = r.localScale.x / flipTime;
        cardText.text = textEsp;
    }

    void Update()
    {
        if (isFlipping)
        {
            Vector3 v = r.localScale;
            v.x += isShrinking * distancePerTime * Time.deltaTime;
            r.localScale = v;

            timeCount += Time.deltaTime;
            if ((timeCount >= flipTime) && (isShrinking < 0))
            {
                isShrinking = 1; //make it grow
                timeCount = 0;
                if (faceSide == 0)
                {
                    faceSide = 1;
                    cardText.text = textJap;
                }
                else
                {
                    faceSide = 0;
                    cardText.text = textEsp;
                }

            }
            else if ((timeCount >= flipTime) && (isShrinking == 1))
            {
                isFlipping = false;
            }
        }
    }



    public void FlipCard()
    {
        if(!isFlipping)
        {
            timeCount = 0;
            isFlipping = true;
            isShrinking = -1;
        }
    }
}