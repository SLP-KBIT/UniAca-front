using UnityEngine;
using System.Collections;

public class Decision : MonoBehaviour {

    public GameObject CorrectText;
    public GameObject IncorrectText;
    public GameObject amimatorControll;
    public GameObject GameController;
    public answerReturn answerReturn;
    public int selectAnswer;

    void start()
    {
        answerReturn = GameController.GetComponent<answerReturn>();
    }

    public void OnClick(int ClickNumber)
    {
        //var answerReturn = GetComponent<answerReturn>();
        //answerReturn.ansewer(number);
        selectAnswer = ClickNumber;

        switch (ClickNumber)
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

        }
        //answerReturn.postAnswer();
        StartCoroutine("postProcessing");
       
    }

    private IEnumerator postProcessing()
    {
        yield return new WaitForSeconds(3);

        amimatorControll.SendMessage("waitMotion");
        CorrectText.SetActive(false);
        IncorrectText.SetActive(false);

        GameController.SendMessage("getQuestionControll");
    }
    
    private void correctAction()
    {
        CorrectText.SetActive(true);
        amimatorControll.SendMessage("correctMotion");   
    }

    private void incorrectAction()
    {
        IncorrectText.SetActive(true);
        amimatorControll.SendMessage("incorrectMotion");
    }

}
