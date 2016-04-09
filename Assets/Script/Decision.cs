using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using LitJson;

public class Decision : MonoBehaviour {

    public GameObject CorrectText;
    public GameObject IncorrectText;
    public GameObject amimatorControll;
    public GameObject GameController;
   // public answerReturn answerReturn;
    public int selectAnswer;

    public void OnClick(int ClickNumber)
    {
        var answerReturn = GameController.GetComponent<answerReturn>();
        var timerCount = GameController.GetComponent<TimerCount>();
        var numberControll = GetComponent<NumberControll>();
        var question = GetComponent<Question>();

        //answerReturn.ansewer(number);
        selectAnswer = ClickNumber;

        timerCount.count = false;
        Debug.Log(selectAnswer);
        /*switch (ClickNumber)
        {
            case 0:
                correctAction();
                break;
            case 1:
                incorrectAction();
                break;
            case 2:
                incorrectAction();
                break;
            case 3:
                incorrectAction();
                break;

        }*/
        GameController.SendMessage("postAnswer");

        
        StartCoroutine("postProcessing");
    }

    private IEnumerator postProcessing()
    {
        var timerCount = GameController.GetComponent<TimerCount>();
        yield return new WaitForSeconds(3);

        amimatorControll.SendMessage("waitMotion");
        CorrectText.SetActive(false);
        IncorrectText.SetActive(false);

        GameController.SendMessage("getQuestionControll");
        timerCount.count = true;
    }
    
    public void correctAction()
    {
        CorrectText.SetActive(true);
        amimatorControll.SendMessage("correctMotion");   
    }

    public void incorrectAction()
    {
        IncorrectText.SetActive(true);
        amimatorControll.SendMessage("incorrectMotion");
    }

}
