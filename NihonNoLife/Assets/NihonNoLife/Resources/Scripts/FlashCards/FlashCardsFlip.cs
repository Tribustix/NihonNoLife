using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FlipEspJap
{
    public string espText;
    public string japText;
    public FlipEspJap(string e, string j) 
    {
        espText = e;
        japText = j;
    }
}
public class FlashCardsFlip : MonoBehaviour
{

    public RectTransform r;
    public Text cardText;

    public FlipEspJap[] flipEspJap = new FlipEspJap[5]; 

    private float flipTime = 0.5f;
    private int faceSide = 0; // 0 = front, 1 = back
    private int isShrinking = -1; // -1 = get smaller, 1 = get bigger 
    private bool isFlipping = false;
    private float distancePerTime;
    private int cardNum = 0;
    private float timeCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        flipEspJap[0] = new FlipEspJap("español", "japonés");
        flipEspJap[1] = new FlipEspJap("español2", "japonés2");
        flipEspJap[2] = new FlipEspJap("español3", "japonés3");
        flipEspJap[3] = new FlipEspJap("español4", "japonés4");
        


        distancePerTime = r.localScale.x / flipTime;
        cardText.text = flipEspJap[cardNum].espText;
    }

    // Update is called once per frame
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
                if (faceSide ==0)
                {
                    faceSide = 1;
                    cardText.text = flipEspJap[cardNum].japText;
                    
                }
                else
                {
                    faceSide = 0;
                    cardText.text = flipEspJap[cardNum].espText;

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
        timeCount = 0;
        isFlipping = true;
        isShrinking = -1;
    
    }
}
