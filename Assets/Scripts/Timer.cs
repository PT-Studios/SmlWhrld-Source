using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerLabel;

    private float time;
    private bool stopped = false;

	// Use this for initialization
	void Start () {
        Debug.Log(Application.loadedLevel);
        if(Application.loadedLevel == 0)
            PlayerPrefs.DeleteAll();
    }
	
	// Update is called once per frame
	void Update () {
        if (!stopped)
        {
            time += Time.deltaTime;

            float min = time / 60;
            float sec = time % 60;
            float fraction = (time * 100) % 100;

            timerLabel.text = string.Format("{0:00}:{1:000}", sec, fraction);
        } else
        {
            timerLabel.text = timerLabel.text;
        }
        
	}

    public void StopTimer(string level)
    {
        stopped = true;
        SaveTimescore(level, timerLabel.text);
    }

    void SaveTimescore(string level, string timescore)
    {
        PlayerPrefs.SetString(level, timescore);
    }
}
