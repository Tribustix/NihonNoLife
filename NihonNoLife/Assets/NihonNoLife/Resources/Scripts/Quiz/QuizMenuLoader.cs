using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class QuizMenuLoader : MonoBehaviour
{
    public GameObject viewPortContent;
    public GameObject quizButtonPrefab;
    private int fileIndex = 0;

    private void Awake()
    {
        string directory = Application.streamingAssetsPath + "/Json/Quiz";

        DirectoryInfo info = new DirectoryInfo(directory);

        FileInfo[] fileInfo = info.GetFiles();

        foreach (FileInfo file in fileInfo)
        {
            if(!file.Name.Contains(".meta"))
            {
                GameObject currentMenuButton = Instantiate(quizButtonPrefab, viewPortContent.transform);
                currentMenuButton.transform.GetChild(0).GetComponent<TMP_Text>().text = file.Name.Replace(file.Extension, "");
                currentMenuButton.GetComponent<QuizMenuButton>().index = fileIndex;
            }

            fileIndex++;
        }
    }
}
