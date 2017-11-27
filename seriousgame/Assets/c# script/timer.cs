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
        float minutes = ((int)timeSinceStart / 60);
        float seconds = (timeSinceStart % 60);
        minutes.ToString();
        seconds.ToString("f2");
        if (minutes >= 1 ){
            End();
            SceneManager.LoadScene("lvlComplete");
        }
        timedLvl = minutes.ToString() +":" + seconds.ToString(); 
        timerText.text = minutes.ToString() + ":" + seconds.ToString("f2");
    }

    public void End(){
        finnished = true;
    }

}
