using UnityEngine;
using System.Collections;

public class answerReturn : MonoBehaviour {
    private WWW _www;
    private WWWForm _wwwForm;

    // Use this for initialization
    public void ansewer ( int number ) {
        StartCoroutine(postAnswer(number));
	}
	
	// Update is called once per frame
	private IEnumerator postAnswer( int number ) {
        string answer;
        var obj = GameObject.Find("GameController");
        _wwwForm = new WWWForm();
        answer = obj.GetComponent<Question>().getQuestionText(number);
        Debug.Log("" + answer);
        _wwwForm.AddField("", answer);

        if (_www.error != null) { Debug.Log("Error"); }

        _www = new WWW("http://133.92.165.48:9000/api/v1/questions/answer/1/1", _wwwForm);
        yield return _www;
	}
}
