using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class AmimatorControll : MonoBehaviour {

    public Animator animator;
    public GameObject CorrectText;
    public GameObject IncorrectText;
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void correctMotion()
    {
        animator.SetBool("is_correct", true);
    }

    public void incorrectMotion()
    {
        animator.SetBool("is_incorrect", true);
    }

    public void waitMotion()
    {
        animator.SetBool("is_correct", false);
        animator.SetBool("is_incorrect", false);
    }

}
