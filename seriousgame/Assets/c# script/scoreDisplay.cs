using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour {

    public Text fail;
    public Text complete;
    public Text time;
    public Text lvlDif;
    public string ptime;
    public string plvlDif;
    public int pcomplete;
    public int pfail;
    public int page;

    void Start(){
        Cursor.lockState = CursorLockMode.None;
        fail.text = charactercontroler.puzzleFailCount.ToString();
        complete.text = charactercontroler.puzzleCompleteCount.ToString();
        time.text = timer.timedLvl.ToString();
        lvlDif.text = lvlselect.difficultySelect;

        ptime = timer.timedLvl.ToString();
        plvlDif = lvlselect.difficultySelect;
        pcomplete = charactercontroler.puzzleCompleteCount;
        pfail = charactercontroler.puzzleFailCount;
        page = mainMenu.Age;

        analytics.analyticUpdate(ptime,plvlDif,pcomplete,pfail,page);
    } 
}