using UnityEngine;
using System.Collections;

public class Decision : MonoBehaviour {

    public GameObject CorrectText;
    public GameObject IncorrectText;

    public void OnClick(int number)
    {
        switch (number)
        {
            case 0:
                CorrectText.SetActive(true);
                break;
            case 1:
                IncorrectText.SetActive(true);
                break;
            case 2:
                IncorrectText.SetActive(true);
                break;
            case 3:
                IncorrectText.SetActive(true);
                break;

        }

        StartCoroutine("postProcessing");
       
    }

    private IEnumerator postProcessing()
    {
        yield return new WaitForSeconds(2);

        CorrectText.SetActive(false);
        IncorrectText.SetActive(false);

        Question question = GetComponent<Question>();
        question.getQuestionControll();
    }
}
