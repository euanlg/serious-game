using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class analytics : MonoBehaviour{

    public static void analyticUpdate(string name, string time, string lvlDif, int puzzleWin, int puzzleLose, int Age){

        if (lvlDif == "Easy"){
            Analytics.CustomEvent("Easy Difficulty", new Dictionary<string, object>{
             {"Player Name: ", name + " Age: " + Age + " Time: " + time + " Puzzles Complete: " + puzzleWin + " Puzzles Failed: " + puzzleLose},
            });
        }

        if (lvlDif == "Medium"){
            Analytics.CustomEvent("Medium Difficulty", new Dictionary<string, object>{
            {"Player Name: ", name + " Age: " + Age + " Time: " + time + " Puzzles Complete: " + puzzleWin + " Puzzles Failed: " + puzzleLose},
            });
        }
    }
}
