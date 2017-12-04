using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabSpawn : MonoBehaviour{

    public Transform mazeSpawnLocation;
    public Transform[] puzzleDoorSpawnLocations;
    public Transform[] puzzleSpawnLocations;
    public Transform[] lvlEndSpawnLocations;
    public GameObject[] mazeClonePrefab;
    public GameObject puzzleDoorClonePrefab;
    public GameObject switchPuzzleClonePrefab;
    public GameObject lvlEndClonePrefab;
    public string lvlDif;

    void Start(){
        lvlDif = lvlselect.difficultySelect;

        string mazeName;
        Quaternion[] doorRot = new Quaternion[3];
        doorRot[0] = Quaternion.Euler(0, 0, 0);
        doorRot[1] = Quaternion.Euler(0, 0, 0);
        doorRot[2] = Quaternion.Euler(0, 0, 0);

        Quaternion[] doorRot1 = new Quaternion[3];
        doorRot1[0] = Quaternion.Euler(0, 90, 0);
        doorRot1[1] = Quaternion.Euler(0, 270, 0);
        doorRot1[2] = Quaternion.Euler(0, 0, 0);

        Quaternion[] puzzleRot = new Quaternion[3];
        puzzleRot[0] = Quaternion.Euler(0, 0, 0);
        puzzleRot[1] = Quaternion.Euler(0, 180, 0);
        puzzleRot[2] = Quaternion.Euler(0, 0, 0);

        Quaternion[] puzzleRot1 = new Quaternion[3];
        puzzleRot1[0] = Quaternion.Euler(0, 90, 0);
        puzzleRot1[1] = Quaternion.Euler(0, 90, 0);
        puzzleRot1[2] = Quaternion.Euler(0, 180, 0);

        if (lvlDif == "Easy") {
            mazeName = "MazeOne";
            spawnMaze(mazeName, 0);
            spawnPuzzles(0, 3, puzzleRot[0], puzzleRot[1], puzzleRot[2]);
            spawnPuzzleDoors(0, 3, doorRot[0], doorRot[1], doorRot[2]);
            lvlEndSpawn(0);
        }
        else if (lvlDif == "Medium") {
            mazeName = "MazeTwo";
            spawnMaze(mazeName, 1);
            spawnPuzzles(3, 6, puzzleRot1[0], puzzleRot1[1], puzzleRot1[2]);
            spawnPuzzleDoors(3, 6, doorRot1[0], doorRot1[1], doorRot1[2]);
            lvlEndSpawn(1);
        }
    }

    void spawnMaze(string mazeName, int maze){
        mazeClonePrefab[0] = Instantiate(mazeClonePrefab[maze], mazeSpawnLocation.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        mazeClonePrefab[0].name = mazeName;
    }

    void lvlEndSpawn(int endlvl) {
        lvlEndClonePrefab = Instantiate(lvlEndClonePrefab, lvlEndSpawnLocations[endlvl].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        lvlEndClonePrefab.name = "endlvl";
    }

    void spawnPuzzleDoors(int start, int end, Quaternion rot1, Quaternion rot2, Quaternion rot3){
        for (int i = 1; start < end; start++, i++){
            switch (start){
                case 0:
                    puzzleDoorClonePrefab = Instantiate(puzzleDoorClonePrefab, puzzleDoorSpawnLocations[start].transform.position, rot1) as GameObject;
                    puzzleDoorClonePrefab.name = "puzzleDoor" + i.ToString();
                    break;
                case 1:
                    puzzleDoorClonePrefab = Instantiate(puzzleDoorClonePrefab, puzzleDoorSpawnLocations[start].transform.position, rot2) as GameObject;
                    puzzleDoorClonePrefab.name = "puzzleDoor" + i.ToString();
                    break;
                case 2:
                    puzzleDoorClonePrefab = Instantiate(puzzleDoorClonePrefab, puzzleDoorSpawnLocations[start].transform.position, rot3) as GameObject;
                    puzzleDoorClonePrefab.name = "puzzleDoor" + i.ToString();
                    break;
                case 3:
                    puzzleDoorClonePrefab = Instantiate(puzzleDoorClonePrefab, puzzleDoorSpawnLocations[start].transform.position, rot1) as GameObject;
                    puzzleDoorClonePrefab.name = "puzzleDoor" + i.ToString();
                    break;
                case 4:
                    puzzleDoorClonePrefab = Instantiate(puzzleDoorClonePrefab, puzzleDoorSpawnLocations[start].transform.position, rot2) as GameObject;
                    puzzleDoorClonePrefab.name = "puzzleDoor" + i.ToString();
                    break;
                case 5:
                    puzzleDoorClonePrefab = Instantiate(puzzleDoorClonePrefab, puzzleDoorSpawnLocations[start].transform.position, rot3) as GameObject;
                    puzzleDoorClonePrefab.name = "puzzleDoor" + i.ToString();
                    break;
            }
        }
    }

    void spawnPuzzles(int start, int end, Quaternion rot1, Quaternion rot2, Quaternion rot3){
        for (int i = 1; start < end; start++, i++){
            switch (start){
                case 0:
                    switchPuzzleClonePrefab = Instantiate(switchPuzzleClonePrefab, puzzleSpawnLocations[start].transform.position, rot1) as GameObject;
                    switchPuzzleClonePrefab.name = "colorSwitchPuzzle" + i.ToString();
                    switchPuzzleClonePrefab.tag = "puzzle";
                    foreach (Transform child in switchPuzzleClonePrefab.transform){
                        child.gameObject.tag = "color0";
                    }
                    break;
                case 1:
                    switchPuzzleClonePrefab = Instantiate(switchPuzzleClonePrefab, puzzleSpawnLocations[start].transform.position, rot2) as GameObject;
                    switchPuzzleClonePrefab.name = "colorSwitchPuzzle" + i.ToString();
                    switchPuzzleClonePrefab.tag = "puzzle";
                    foreach (Transform child in switchPuzzleClonePrefab.transform){
                        child.gameObject.tag = "color1";
                    }
                    break;
                case 2:
                    switchPuzzleClonePrefab = Instantiate(switchPuzzleClonePrefab, puzzleSpawnLocations[start].transform.position, rot3) as GameObject;
                    switchPuzzleClonePrefab.name = "colorSwitchPuzzle" + i.ToString();
                    switchPuzzleClonePrefab.tag = "puzzle";
                    foreach (Transform child in switchPuzzleClonePrefab.transform){
                        child.gameObject.tag = "color2";
                    }
                    break;
                case 3:
                    switchPuzzleClonePrefab = Instantiate(switchPuzzleClonePrefab, puzzleSpawnLocations[start].transform.position, rot1) as GameObject;
                    switchPuzzleClonePrefab.name = "colorSwitchPuzzle" + i.ToString();
                    switchPuzzleClonePrefab.tag = "puzzle";
                    foreach (Transform child in switchPuzzleClonePrefab.transform){
                        child.gameObject.tag = "color0";
                    }
                    break;
                case 4:
                    switchPuzzleClonePrefab = Instantiate(switchPuzzleClonePrefab, puzzleSpawnLocations[start].transform.position, rot2) as GameObject;
                    switchPuzzleClonePrefab.name = "colorSwitchPuzzle" + i.ToString();
                    switchPuzzleClonePrefab.tag = "puzzle";
                    foreach (Transform child in switchPuzzleClonePrefab.transform){
                        child.gameObject.tag = "color1";
                    }
                    break;
                case 5:
                    switchPuzzleClonePrefab = Instantiate(switchPuzzleClonePrefab, puzzleSpawnLocations[start].transform.position, rot3) as GameObject;
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


