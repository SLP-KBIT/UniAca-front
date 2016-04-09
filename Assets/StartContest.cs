using UnityEngine;
using System.Collections;
using MiniJSON;
using LitJson;
using System.Collections.Generic;
using System;

public class StartContest : MonoBehaviour {

    public static string attendID;

	// Use this for initialization
	void Start () {
        StartCoroutine("GetAttendID");
    }

    public IEnumerator GetAttendID()
    {
        var question = GetComponent<Question>();
        string url = "http://133.92.165.48:9000/api/v1/contests/new";
        long temp;
        WWW www = new WWW(url);
        yield return www;

        var json = Json.Deserialize(www.text) as IDictionary<string, object>;
        Debug.Log(www.text);
        temp = (long)json["results"];
        attendID = temp.ToString();
        Debug.Log(attendID);
        question.getQuestionControll();
    }

    public string getAttendID()
    {
        return attendID;
    }

}
