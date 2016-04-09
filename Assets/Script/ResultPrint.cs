using UnityEngine;
using System.Collections;
using MiniJSON;
using LitJson;
using System.Collections.Generic;
using System;

public class ResultPrint : MonoBehaviour {

    public UnityEngine.UI.Text ResultText;

    // Use this for initialization
    void Start () {
        StartCoroutine("QuestionControll");
    }

    public IEnumerator QuestionControll()
    {
        string url = "http://133.92.165.48:9000/api/v1/contests/result/";
        url += StartContest.attendID;
        Debug.Log(url);
        WWW www = new WWW(url);
        long result = 0;
        yield return www;
        var numberControll = GetComponent<NumberControll>();
        var textAsset = Resources.Load("sample") as TextAsset;
        var jsonText = textAsset.text;

        Debug.Log(www.text);

        var json = Json.Deserialize(www.text) as IDictionary<string, object>;
        result = (long)json["results"];
        ResultText.text += result.ToString();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
