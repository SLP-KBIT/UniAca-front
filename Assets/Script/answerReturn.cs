using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class answerReturn : MonoBehaviour {
    private WWW _www;
    private WWWForm _wwwForm;
    public GameObject Canvas;
   Question question;

    // Use this for initialization
    /* public void answer ( int number ) {
         //StartCoroutine(postAnswer(number));
         postAnswer(number);
     }*/

    public void postAnswer () {
        var decision = GetComponent<Decision>();
        string ans = "";

        switch (decision.selectAnswer)
        {
            case 1:
                ans = question.buttonLabel1.text; break;
            case 2:
                ans = question.buttonLabel1.text; break;
            case 3:
                ans = question.buttonLabel1.text; break;
            case 4:
                ans = question.buttonLabel1.text; break;
        }
        Debug.Log("num"+ans);
        /*_wwwForm = new WWWForm();

        //_wwwForm.AddField("answer",ans);

        if (_www.error != null) { Debug.Log("Error"); }

        _www = new WWW("http://133.92.165.48:9000/api/v1/questions/answer/1/1", _wwwForm);
        yield return _www;*/
	}
}
