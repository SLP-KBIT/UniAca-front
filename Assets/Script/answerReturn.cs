using UnityEngine;
using System.Collections;
using MiniJSON;
using LitJson;
using System.Collections.Generic;
using System;

public class answerReturn : MonoBehaviour {
    private WWW www;
    private WWWForm wwwForm;
    public GameObject Canvas;
    public string results;

    public void postAnswer () {
        var decision = Canvas.GetComponent<Decision>();
        var question = GetComponent<Question>();
        string url = "http://133.92.165.48:9000/api/v1/question/";
        string ans = "";
        int num;
        

        url = url + StartContest.attendID + "/";
        num = question.getQuestionNumber() - 1;
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
        Debug.Log(url);
        Debug.Log(ans);
        wwwForm = new WWWForm();

        wwwForm.AddField("answer",ans);

        www = new WWW(url, wwwForm);

        StartCoroutine(WaitForRequest(www));

        Debug.Log(results);

        if (www.error != null) {
            Debug.Log("Error");
        } else if (www.isDone) {
            Debug.Log("post"+www.text);
        }
	}

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        string correct = "correct";
        var decision = Canvas.GetComponent<Decision>();
        var textAsset = Resources.Load("sample") as TextAsset;
        var jsonText = textAsset.text;

        // 文字列を json に合わせて構成された辞書に変換
        var json = Json.Deserialize(www.text) as Dictionary<string, object>;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            results = (string)json["results"];
            Debug.Log(results);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }

        if (results == correct)
        {
            decision.correctAction();
        }
        else
        {
            decision.incorrectAction();
        }
    }
}
