using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class QuizManager : MonoBehaviour
{
    [Header("Questions")]
    public GameObject[] options;
    public int currentQuestion;

    [Header("Text")]
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI backgroundText;
    public TextMeshProUGUI correctNumber;
    public TextMeshProUGUI wrongNumber;

    [SerializeField] private string correctText;
    [SerializeField] private string wrongText;

    [Header("Panels")]
    public GameObject quizPanel;
    public GameObject resultsPanel;

    [Header("Quiz Information")]
    public TextAsset textJSON;
    public int fileSelected = 0;

    [SerializeField] private float waitTime;

    private int correctAnswers = 0;
    private int wrongAnswers = 0;

    [Serializable]
    public class QuestionsAnswersList
    {
        public List<QuestionsAnswers> QnA;
    }

    public QuestionsAnswersList QnAList;

    //making sure the correct panels are active at the beginning of the quiz and generate one question from the pool at random
    private void Start()
    {
       
    }

    private void OnEnable()
    {
        string directory = Application.streamingAssetsPath + "/Json/Quiz";

        DirectoryInfo info = new DirectoryInfo(directory);

        FileInfo[] fileInfo = info.GetFiles();

        string name = fileInfo[fileSelected].FullName;

        textJSON = new TextAsset(File.ReadAllText(name));

        QnAList = new QuestionsAnswersList();
        QnAList = JsonUtility.FromJson<QuestionsAnswersList>(textJSON.text);


        backgroundText.text = null;
        resultsPanel.SetActive(false);
        quizPanel.SetActive(true);
        GenerateQuestion();
    }

    private void OnDisable()
    {
        correctAnswers = 0;
        wrongAnswers = 0;

        QnAList.QnA.Clear();
    }

    //called when the selected answer is correct. It adds to the correct score and displays the correct message
    public void Correct()
    {
        correctAnswers++;

        StartCoroutine(CorrectMessage());
    }

    //called when the selected answer is wrong. It adds to the wrong score and displays the wrong message
    public void Wrong()
    {
        wrongAnswers++;

        StartCoroutine(WrongMessage());
    }

    //it sets the multiple choice answers in the buttons depending on the question that has been generated. 
    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;

            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnAList.QnA[currentQuestion].answers[i];

            if (QnAList.QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    //generates one question at random from the pool. It is called at the beginning of the quiz and after each answer. When there are no more questions available, it moves to the final score
    private void GenerateQuestion()
    {
        if (QnAList.QnA.Count > 0)
        {
            currentQuestion = UnityEngine.Random.Range(0, QnAList.QnA.Count);

            questionText.text = QnAList.QnA[currentQuestion].question;

            SetAnswers();
        }
        else
        {
            quizPanel.SetActive(false);

            correctNumber.text = correctAnswers.ToString();
            wrongNumber.text = wrongAnswers.ToString();

            resultsPanel.SetActive(true);
        }
        
    }

    //displays the "correct!" message for a set duration before moving to the next question
    IEnumerator CorrectMessage()
    {
        backgroundText.text = correctText;
        quizPanel.SetActive(false);

        yield return new WaitForSeconds(waitTime);

        QnAList.QnA.RemoveAt(currentQuestion);
        backgroundText.text = null;
        quizPanel.SetActive(true);
        GenerateQuestion();

        StopCoroutine(CorrectMessage());
    }

    //displays the "wrong" message for a set duration before moving to the next question
    IEnumerator WrongMessage()
    {
        backgroundText.text = wrongText;
        quizPanel.SetActive(false);

        yield return new WaitForSeconds(waitTime);

        QnAList.QnA.RemoveAt(currentQuestion);
        backgroundText.text = null;
        quizPanel.SetActive(true);
        GenerateQuestion();

        StopCoroutine(WrongMessage());
    }
}
