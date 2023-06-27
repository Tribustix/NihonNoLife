using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashCardSlider: MonoBehaviour
{
    public GameObject ContainerPanel;
    public GameObject[] Panels;
    int currentIndex = 0;
    float containerPositionX;

    void Start()
    {
        containerPositionX = ContainerPanel.transform.position.x;
    }

    public void SlideToLeft()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            var targetPanel = Panels[currentIndex];
            float targetPositionX = containerPositionX - targetPanel.transform.position.x;
            var targetPosition = new Vector3(ContainerPanel.transform.position.x + targetPositionX, ContainerPanel.transform.position.y, ContainerPanel.transform.position.z);
            iTween.MoveTo(ContainerPanel, targetPosition, 0.5f);

        }
    }

    public void SlideToRight()
    {
        if (currentIndex < Panels.Length - 1)
        {
            currentIndex++;
            var targetPanel = Panels[currentIndex];
            float targetPositionX = containerPositionX - targetPanel.transform.position.x;
            var targetPosition = new Vector3(ContainerPanel.transform.position.x + targetPositionX, ContainerPanel.transform.position.y, ContainerPanel.transform.position.z);
            iTween.MoveTo(ContainerPanel, targetPosition, 0.5f);
        }
    }

}

