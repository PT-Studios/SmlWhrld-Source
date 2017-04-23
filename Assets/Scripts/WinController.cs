using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour {

    public Transform winCube;
    public Timer timer;

    float scale;
    float scaleBuffer;
    float winScale;
    bool win = false;
    AudioSource audiox;

	// Use this for initialization
	void Start () {
        scale = transform.parent.transform.localScale.x;
        scaleBuffer = (scale / 4);
        audiox = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log((scale - scaleBuffer) + " :Win minscale, " + (scale + scaleBuffer) + "Win maxscale, " + winScale + " :Cube scale");
        winScale = winCube.transform.localScale.x;
        if (winScale >= scale - scaleBuffer && winScale <= scale + scaleBuffer && win)
        {
            StartCoroutine(ChangeLevel());
            audiox.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject gO;
        gO = other.gameObject;
        if (gO.tag == "WinCube")
        {
            win = true;
            timer.StopTimer("Level "+ Application.loadedLevel);
            Debug.Log("Game Win");
        }
    }

    IEnumerator ChangeLevel()
    {
        win = false;
        float fadeTime = GameObject.Find("_GM").GetComponent<Fade>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(Application.loadedLevel + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene.);
    }
}
