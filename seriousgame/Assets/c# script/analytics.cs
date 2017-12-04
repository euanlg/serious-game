using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class analytics : MonoBehaviour {

    public  static void analyticUpdate(string time, string lvlDif, int puzzleWin, int puzzleLose, int Age) {

        Analytics.CustomEvent("end", new Dictionary<string, object>
        {
            {"timeTaken", time },
            {"lvlDif", lvlDif},
            {"puzzlesComplete", puzzleWin},
            {"puzzlesFailed", puzzleLose},
            {"playerAge", Age}
        });
    }
}
