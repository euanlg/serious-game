using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {

    public static string timedLvl = "00:00:00";
	public Text timerText;
    private float startTime;
    private bool finnished = false;

    void Start(){
        startTime = Time.time;
    }

    void Update(){
        if (finnished)
            return;
        float timeSinceStart = Time.time - startTime;
        string minutes = ((int)timeSinceStart / 60).ToString();
        string seconds = (timeSinceStart % 60).ToString("f2");
        if (minutes == "2"){
            End();
            SceneManager.LoadScene("lvlComplete");
        }
        timedLvl = minutes +":" + seconds;
        timerText.text = minutes + ":" + seconds;
    }

    public void End(){
        finnished = true;
    }

}
