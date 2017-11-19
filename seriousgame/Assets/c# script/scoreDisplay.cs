using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour {

    public Text fail;
    public Text complete;
    public Text time;

    void Start(){
        fail.text = charactercontroler.puzzleFailCount.ToString();
        complete.text = charactercontroler.puzzleCompleteCount.ToString();
        time.text = timer.timedLvl.ToString();
    } 
}