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
    private string lvlDif;

    void Start(){
        startTime = Time.time;
        lvlDif = lvlselect.difficultySelect;
    }

    void Update(){
        if (finnished)
            return;
        float timeSinceStart = Time.time - startTime;
        float minutes = ((int)timeSinceStart / 60);
        float seconds = (timeSinceStart % 60);
        minutes.ToString();
        seconds.ToString("f2");
        if(lvlDif == "Easy"){
            easylvlTime(minutes,seconds);
        }
        else if (lvlDif == "Medium"){
            mediumlvlTime(minutes,seconds);
        }
        
        timedLvl = minutes.ToString() +":" + seconds.ToString("f2"); 
        timerText.text = minutes.ToString() + ":" + seconds.ToString("f2");
    }

    void easylvlTime(float minutes, float seconds){
        if (minutes >= 1 && seconds >= 30)
        {
            End();
            SceneManager.LoadScene("lvlComplete");
        }
    }

    void mediumlvlTime(float minutes, float seconds){
        if (minutes >= 1 && seconds >= 45){
            End();
            SceneManager.LoadScene("lvlComplete");
        }
    }

    public void End(){
        finnished = true;
    }

}
