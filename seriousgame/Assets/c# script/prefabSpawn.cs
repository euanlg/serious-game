using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabSpawn : MonoBehaviour{

    public Transform mazeSpawnLocation;
    public Transform[] puzzleDoorSpawnLocations;
    public Transform[] puzzleSpawnLocations;
    public GameObject[] mazeClonePrefab;
    public GameObject puzzleDoorClonePrefab;
    public GameObject switchPuzzleClonePrefab;

    void Awake(){
        spawnMaze();
        spawnPuzzles();
        spawnPuzzleDoors();
    }

    void spawnMaze(){
        mazeClonePrefab[0] = Instantiate(mazeClonePrefab[0], mazeSpawnLocation.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        mazeClonePrefab[0].name = "mazeOne";
    }

    void spawnPuzzleDoors(){
        for (int x = 0, i = 1; x < 3; x++, i++){
            puzzleDoorClonePrefab = Instantiate(puzzleDoorClonePrefab, puzzleDoorSpawnLocations[x].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            puzzleDoorClonePrefab.name = "puzzleDoor" + i.ToString();
        }
    }

    void spawnPuzzles(){
        for (int x = 0, i = 1; x < 3; x++, i++){
            switch (x){
                case 0:
                    switchPuzzleClonePrefab = Instantiate(switchPuzzleClonePrefab, puzzleSpawnLocations[x].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    switchPuzzleClonePrefab.name = "colorSwitchPuzzle" + i.ToString();
                    switchPuzzleClonePrefab.tag = "puzzle";
                    foreach (Transform child in switchPuzzleClonePrefab.transform){
                        child.gameObject.tag = "color0";
                    }
                    break;
                case 1:
                    switchPuzzleClonePrefab = Instantiate(switchPuzzleClonePrefab, puzzleSpawnLocations[x].transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
                    switchPuzzleClonePrefab.name = "colorSwitchPuzzle" + i.ToString();
                    switchPuzzleClonePrefab.tag = "puzzle";
                    foreach (Transform child in switchPuzzleClonePrefab.transform){
                        child.gameObject.tag = "color1";
                    }
                    break;
                case 2:
                    switchPuzzleClonePrefab = Instantiate(switchPuzzleClonePrefab, puzzleSpawnLocations[x].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    switchPuzzleClonePrefab.name = "colorSwitchPuzzle" + i.ToString();
                    switchPuzzleClonePrefab.tag = "puzzle";
                    foreach (Transform child in switchPuzzleClonePrefab.transform){
                        child.gameObject.tag = "color2";
                    }
                    break;
            }
        }
    }
}


