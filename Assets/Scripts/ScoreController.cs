using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.None;
        int rectH = 220;
        for (int i = 0; i <= Application.levelCount-2; i++)
        {
            GameObject newText = new GameObject("ScoreText");
            newText.transform.SetParent(this.transform);

            Text scoreLabel = newText.AddComponent<Text>();
            scoreLabel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            scoreLabel.GetComponent<RectTransform>().sizeDelta = new Vector2(300, rectH);
            scoreLabel.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            scoreLabel.GetComponent<Text>().font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            scoreLabel.GetComponent<Text>().fontStyle = FontStyle.Bold;
            scoreLabel.GetComponent<Text>().fontSize = 16;
            scoreLabel.GetComponent<Text>().color = Color.black;
            scoreLabel.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
            scoreLabel.text = "Level "+ i + " - " + GetTimescore("Level "+i);
            rectH = rectH - 40;
        }
        

        //scoreLabel.text = GetTimescore("Level 1");
        //scoreLabel.text = GetTimescore("Level 2");
        //scoreLabel.text = GetTimescore("Level 3");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        bool quitGame = GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 200, 200, 20), "Quit");
        if (quitGame)
            Application.Quit();
        bool retry = GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 170, 200, 20), "Try Again");
        if (retry)
            Application.LoadLevel("Level_1");
    }

    public string GetTimescore(string level)
    {
        return PlayerPrefs.GetString(level);
    }
}
