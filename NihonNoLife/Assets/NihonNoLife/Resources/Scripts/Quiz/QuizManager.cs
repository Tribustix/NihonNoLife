using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI questionText;

    private void Start()
    {
        
    }

    public void Correct()
    {
        QnA.RemoveAt(currentQuestion);
    }
    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;

            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].answers[i];

            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    private void GenerateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        questionText.text = QnA[currentQuestion].question;

        SetAnswers();
    }
}
