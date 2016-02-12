using UnityEngine;
using System.Collections;

public class Decision : MonoBehaviour {

    public GameObject CorrectText;
    public GameObject IncorrectText;
    public GameObject amimatorControll;
    public GameObject GameController;

    public void OnClick(int number)
    {
        //GameController.SendMessage("answer", number);

        switch (number)
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
