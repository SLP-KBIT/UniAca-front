using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerCount : MonoBehaviour {
    public float timer;
    public const float  Limit = 10;
    public float length;
    public bool count = true;
    public UnityEngine.UI.Text TimeLabel;
    public GameObject Canvas;
    public Slider slider;
    
    void start ()
    {
        timer = Limit;
    }

    // Update is called once per frame
    void Update () {
        var decision = Canvas.GetComponent<Decision>();
        if ( timer > 0.1 && count ) {
            timer -= Time.deltaTime;
        } else if ( !count ) {
            timer = Limit;
        } else if ( timer < 0.1 ) {
            decision.incorrectAction();
            timer = Limit;
            count = false;
            decision.StartCoroutine("postProcessing");
        }
        TimeLabel.text = timer.ToString();
        slider.value = timer;
    }
}
