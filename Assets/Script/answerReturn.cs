using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class answerReturn : MonoBehaviour {
    private WWW _www;
    private WWWForm _wwwForm;
    public GameObject Canvas;

    // Use this for initialization
    /* public void answer ( int number ) {
         //StartCoroutine(postAnswer(number));
         postAnswer(number);
     }*/

    public void postAnswer () {
        var decision =Canvas.GetComponent<Decision>();
        var question = GetComponent<Question>();
        string ans = "";
        Debug.Log(decision.selectAnswer);
        switch (decision.selectAnswer)
        {
            case 0:
                ans = question.buttonLabel1.text; break;
            case 1:
                ans = question.buttonLabel2.text; break;
            case 2:
                ans = question.buttonLabel3.text; break;
            case 3:
                ans = question.buttonLabel4.text; break;
        }
        Debug.Log(ans);
        /*_wwwForm = new WWWForm();

        //_wwwForm.AddField("answer",ans);

        if (_www.error != null) { Debug.Log("Error"); }

        _www = new WWW("http://133.92.165.48:9000/api/v1/questions/answer/1/1", _wwwForm);
        yield return _www;*/
	}
}
