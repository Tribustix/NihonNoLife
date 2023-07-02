using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class FlashCardMenuLoader : MonoBehaviour
{
    public GameObject viewPortContent;
    public GameObject flashCardButtonPrefab;
    private int fileIndex = 0;

    private void Awake()
    {
        string directory = Application.streamingAssetsPath + "/Json/Flashcard";

        DirectoryInfo info = new DirectoryInfo(directory);

        FileInfo[] fileInfo = info.GetFiles();

        foreach (FileInfo file in fileInfo)
        {
            if(!file.Name.Contains(".meta"))
            {
                GameObject currentMenuButton = Instantiate(flashCardButtonPrefab, viewPortContent.transform);
                currentMenuButton.transform.GetChild(0).GetComponent<TMP_Text>().text = file.Name.Replace(file.Extension, "");
                currentMenuButton.GetComponent<FlashCardMenuButton>().index = fileIndex;
            }

            fileIndex++;
        }
    }
}
