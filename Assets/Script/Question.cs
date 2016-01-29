using UnityEngine;
using System.Collections;
using MiniJSON;
using LitJson;
using System.Collections.Generic;

public class Question : MonoBehaviour {

    public UnityEngine.UI.Text questionLabel;
    public UnityEngine.UI.Text buttonLabel1;
    public UnityEngine.UI.Text buttonLabel2;
    public UnityEngine.UI.Text buttonLabel3;
    public UnityEngine.UI.Text buttonLabel4;
    public string questiontext = "text";
    public string buttontext1 = "正解";
    public string buttontext2 = "不正解";
    public string buttontext3 = "不正解";
    public string buttontext4 = "不正解";

    void Start()
    {
        StartCoroutine("QuestionControll");
    }

    public void getQuestionControll()
    {
        StartCoroutine("QuestionControll");
    }

    public IEnumerator QuestionControll()
    {
        string url = "http://133.92.165.48:9000/questions/get/1/1";
        WWW www = new WWW(url);
        yield return www;
        var textAsset = Resources.Load("sample") as TextAsset;
        var jsonText = textAsset.text;

        var json = Json.Deserialize(www.text) as IDictionary<string, object>;
        JsonData jsonData = JsonMapper.ToObject(www.text);
        questionLabel.text = (string)json["text"];
        buttonLabel1.text = (string)jsonData["choices"][0];
        buttonLabel2.text = (string)jsonData["choices"][1];
        buttonLabel3.text = (string)jsonData["choices"][2];
        buttonLabel4.text = (string)jsonData["choices"][3];
    }
}
