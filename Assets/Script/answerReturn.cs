using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class answerReturn : MonoBehaviour {
    private WWW www;
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
        string url = "http://133.92.165.48:9000/api/v1/questions/answer/1/";
        string ans = "";
        int num;
        num = question.getQuestionNumber();
        url = url + num.ToString();
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
        _wwwForm = new WWWForm();

        _wwwForm.AddField("answer",ans);

        www = new WWW(url, _wwwForm);

        StartCoroutine(WaitForRequest(www));

        if (www.error != null) {
            Debug.Log("Error");
        } else if (www.isDone) {
            Debug.Log("post"+www.text);
        }
	}

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
