using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizMger;
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizMger.Correct();

        }
        else
        {
            Debug.Log("Incorrect Answer");
        }
    }
}
