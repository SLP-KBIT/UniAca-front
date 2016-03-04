using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerCount : MonoBehaviour {
    public float timer;
    public const float  Limit = 10;
    public float length;
    public UnityEngine.UI.Text TimeLabel;
    Slider slider;

    void start ()
    {
        timer = Limit;
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update () {
        if (timer > 0.1) { timer -= Time.deltaTime; }
        TimeLabel.text = timer.ToString();
        //slider.value = timer / Limit;
    }
}
