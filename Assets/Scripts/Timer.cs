using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private string timerDisplay;
    private bool stopTimer;
    private float beginVal;
    private float timer;

	// Use this for initialization
	void Start () {
        beginVal = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        DisplayText();
	}

    void ResetTimer()
    {
        timer = beginVal;
    }

    void DisplayText()
    {
        int min = Mathf.FloorToInt(timer / 60F);
        int sec = Mathf.FloorToInt(timer - min * 60);
        timerDisplay = string.Format("{0:0}:{1:00}", min, sec);

        timerText.text = timerDisplay;
    }
}
