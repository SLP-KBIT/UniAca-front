using UnityEngine;
using System.Collections;
using MiniJSON;
using LitJson;
using System.Collections.Generic;
using System;

public class Question : MonoBehaviour {

    public UnityEngine.UI.Text questionLabel;
    public UnityEngine.UI.Text buttonLabel1;
    public UnityEngine.UI.Text buttonLabel2;
    public UnityEngine.UI.Text buttonLabel3;
    public UnityEngine.UI.Text buttonLabel4;
    private int number = 1;

    void Start()
    {

    }

    public void getQuestionControll()
    {
        if (number > 10) {
            Application.LoadLevel("result");
        } else {
            StartCoroutine("QuestionControll");
        }
    }

    public IEnumerator QuestionControll()
    {
        var startContest = GetComponent<StartContest>();
        var contestStatusController = GetComponent<ContestStatusController>();
        string temp1 = "http://133.92.165.48:9000/api/v1/questions/";
        string temp2 = number.ToString();
        string url = temp1 + startContest.getAttendID() + "/" + temp2;
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;
        var numberControll = GetComponent<NumberControll>();
        var textAsset = Resources.Load("sample") as TextAsset;
        var jsonText = textAsset.text;

        var json = Json.Deserialize(www.text) as IDictionary<string, object>;
        JsonData jsonData = JsonMapper.ToObject(www.text);
        questionLabel.text = (string)json["text"];
        buttonLabel1.text = (string)jsonData["choices"][0];
        buttonLabel2.text = (string)jsonData["choices"][1];
        buttonLabel3.text = (string)jsonData["choices"][2];
        buttonLabel4.text = (string)jsonData["choices"][3];
        numberControll.numberPrint();
        contestStatusController.FetchContestStatus();
        number += 1;
    }

    public int getQuestionNumber()
    {
        return number;
    }
}
