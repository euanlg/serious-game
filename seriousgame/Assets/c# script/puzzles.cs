using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzles : MonoBehaviour {

    public static int[] colorSwitchRNG = new int[3];
    public static GameObject[] doorPuzzles = new GameObject[3];

    void Start(){
        StartCoroutine(PuzzlesWait());
    }
        
    void checkColorSwitchHasSpawned(){
        string puzzleName;
        doorPuzzles = GameObject.FindGameObjectsWithTag("puzzle");

        for (int x = 0, i = 1 ; x < 3; x++, i++){
            puzzleName = "colorSwitchPuzzle" + i.ToString();
            if (doorPuzzles[x].name == puzzleName){
                colorSwitchPuzzle(x);
            }else if (doorPuzzles[x].name != puzzleName){
                print("colorSwitchPuzzle" + i.ToString() + " has not spawned");
            }
        } 
    }

    void colorSwitchPuzzle(int x){
        GameObject light;
        light = doorPuzzles[x].transform.FindChild("light").gameObject;

        for (int i = 0; i < 15; i++){
            colorSwitchRNG[x] = Random.Range(0, 5);
        }

        switch (colorSwitchRNG[x]){
            case 0:
                light.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                break;
            case 1:
                light.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
                break;
            case 2:
                light.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
                break;
            case 3:
                light.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                break;
            case 4:
                light.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
                break;
        }
    }

    IEnumerator PuzzlesWait(){
        yield return new WaitForSeconds(1);
        checkColorSwitchHasSpawned();
    }
          
}