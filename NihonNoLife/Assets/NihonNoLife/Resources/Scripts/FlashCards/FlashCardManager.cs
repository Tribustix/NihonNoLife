using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlashCardManager : MonoBehaviour
{
    public TextAsset textJSON;

    public GameObject flashCardPrefab;
    public GameObject viewPortContent;

    public int fileSelected = 0;

    public FlashCardList flashCardList;

    [Serializable]
    public class FlashCard
    {
        public string[] wordsEsp;
        public string[] wordsJap;
    }

    [Serializable]
    public class FlashCardList
    {
        public FlashCard flashCard;
    }

    private void Awake()
    {
       
    }

    void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(SetFlashCards());
    }

    private void OnDisable()
    {
        foreach (Transform child in viewPortContent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void Update()
    {

    }

    IEnumerator SetFlashCards()
    {
        yield return new WaitForSeconds(0.05f);

        string directory = Application.streamingAssetsPath + "/Json/Flashcard";

        DirectoryInfo info = new DirectoryInfo(directory);

        FileInfo[] fileInfo = info.GetFiles();

        string name = fileInfo[fileSelected].FullName;

        textJSON = new TextAsset(File.ReadAllText(name));

        flashCardList = new FlashCardList();
        flashCardList = JsonUtility.FromJson<FlashCardList>(textJSON.text);

        for (int i = 0; i < flashCardList.flashCard.wordsEsp.Length; i++)
        {
            GameObject currentFlashCard = Instantiate(flashCardPrefab, viewPortContent.transform);
            currentFlashCard.GetComponent<FlashCardsFlip>().textEsp = flashCardList.flashCard.wordsEsp[i];
            currentFlashCard.GetComponent<FlashCardsFlip>().textJap = flashCardList.flashCard.wordsJap[i];
        }

        
    }
}
