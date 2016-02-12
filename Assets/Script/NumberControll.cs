using UnityEngine;
using System.Collections;

public class NumberControll : MonoBehaviour {
    public UnityEngine.UI.Text number;
    public int num;

    // Use this for initialization
    void Start () {
        var question = GetComponent<Question>();
        num = question.getQuestionNumber();
        number.text = num.ToString();
    }
	
	// Update is called once per frame
	public void numberPrint () {
        var question = GetComponent<Question>();
        num = question.getQuestionNumber();
        number.text = num.ToString();
	}
}
