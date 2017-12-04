using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class analytics : MonoBehaviour {

    public  static void analyticUpdate(string name, string time, string lvlDif, int puzzleWin, int puzzleLose, int Age) {

        Analytics.CustomEvent("end", new Dictionary<string, object>
        {
            {"Time Taken", time },
            {"Level Difficulty", lvlDif},
            {"Puzzles Complete", puzzleWin},
            {"Puzzles Failed", puzzleLose},
            {"Player Age", Age},
            {"Player Name", name}
        });
    }
}
