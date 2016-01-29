using UnityEngine;
using System.Collections;

public class SelectQuestions : MonoBehaviour {
	
	// Update is called once per frame
	void start () {
        Question question = GetComponent<Question>();
        question.questiontext = "test";
	}
}
