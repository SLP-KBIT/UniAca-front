using UnityEngine;
using System.Collections;
using MiniJSON;
using LitJson;
using System.Collections.Generic;
using System;

public class ContestStatusController : MonoBehaviour {

    public UnityEngine.UI.Text ContestStatusText1;
    public UnityEngine.UI.Text ContestStatusText2;
    public UnityEngine.UI.Text ContestStatusText3;
    public UnityEngine.UI.Text ContestStatusText4;

    void start()
    {
        FetchContestStatus();
    }

    public void FetchContestStatus()
    {
        long id;
        string name;
        var textAsset = Resources.Load("contest") as TextAsset;
        var jsonText = textAsset.text;
        Debug.Log(jsonText);
        IList dataList = (IList)Json.Deserialize(jsonText);
        foreach (IDictionary data in dataList) {
            id = (long)data["id"];
            name = (string)data["name"];
            ContestStatusText1.text = name;
        }
    }
}
