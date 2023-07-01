using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizMger;

    //called whenever an answer button is pressed. Depending on the answer, it will call the correct or wrong function from the quiz manager. 
    public void Answer()
    {
        if (isCorrect)
        {
            quizMger.Correct();
        }
        else
        {
            quizMger.Wrong();
        }

        EventSystem.current.SetSelectedGameObject(null);
    }
}
