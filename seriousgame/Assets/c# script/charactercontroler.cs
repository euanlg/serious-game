using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroler : MonoBehaviour
{

    public static float mouseSensitivityX = 85f;
    public static float mouseSensitivityY = 85f;
    public static int puzzleCompleteCount = 0;
    public static int puzzleFailCount = 0;
    private int[] colorSwitchRNG = new int[3];
    private float speed = 4.5f;
    private float forwardBack;
    private float leftRight;
    private float mouseRotX;
    private float mouseRotY;
    private GameObject headCamera;

    void Awake(){
        headCamera = this.transform.FindChild("headCamera").gameObject;
        lockHideCursorToGame();
    }

    void Update(){
        freeCursorEsc();
        rayCastClickCheck();
    }

    private void FixedUpdate(){
        playerHeadMovement();
        playerWalkMovement();
    }

    void playerHeadMovement(){
        mouseRotX += Input.GetAxis("Mouse X") * mouseSensitivityX * Time.fixedDeltaTime;
        mouseRotY -= Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.fixedDeltaTime;
        mouseRotY = Mathf.Clamp(mouseRotY, -60f, 60f);
        transform.rotation = Quaternion.Euler(0, mouseRotX, 0);
        headCamera.transform.rotation = Quaternion.Euler(mouseRotY, mouseRotX, 0);

    }

    void playerWalkMovement(){
        forwardBack = (Input.GetAxis("Vertical") * speed) * Time.fixedDeltaTime;
        leftRight = (Input.GetAxis("Horizontal") * speed) * Time.fixedDeltaTime;
        transform.Translate(leftRight, 0, forwardBack);
    }

    void rayCastClickCheck(){
        if (Input.GetMouseButtonDown(0)){
            rayCastWhenClicked();
        }
        else if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButton(0)){
            rayCastAlways();
        }

    }

    void rayCastAlways(){
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        string objName;

        if (Physics.Raycast(ray, out hit, 40)){
            Debug.DrawLine(ray.origin, hit.point, Color.white);
            objName = hit.collider.gameObject.tag;
            //search for the tag *puzzle*
            //could be used for highlighting the puzzle, providing the player with some visual feedback
        }
    }

    void rayCastWhenClicked(){
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        int puzzledoorNum = 0;

        if (Physics.Raycast(ray, out hit, 40)){
            Debug.DrawLine(ray.origin, hit.point, Color.blue);
            switch (puzzleCompleteCount){
                case 0:
                    puzzledoorNum = 1;
                    colorSwitchRNG[0] = puzzles.colorSwitchRNG[0];
                    rayCastPuzzle(puzzledoorNum, colorSwitchRNG[0], hit);
                    break;
                case 1:
                    puzzledoorNum = 2;
                    colorSwitchRNG[1] = puzzles.colorSwitchRNG[1];
                    rayCastPuzzle(puzzledoorNum, colorSwitchRNG[1], hit);
                    break;
                case 2:
                    puzzledoorNum = 3;
                    colorSwitchRNG[2] = puzzles.colorSwitchRNG[2];
                    rayCastPuzzle(puzzledoorNum, colorSwitchRNG[2], hit);
                    break;
            }
        }
    }


    void rayCastPuzzle(int x, int i, RaycastHit hit){
        if (hit.collider.gameObject.name == "button1"){//color yellow wins on button 1
            switch (i){
                case 0:
                    print("no winbtn1");
                    puzzleFailCount += 1;
                    break;
                case 1:
                    print("winbtn1");
                    lowerDoor(x);
                    break;
                case 2:
                    print("no winbtn1");
                    puzzleFailCount += 1;
                    break;
            }
        }
        else if (hit.collider.gameObject.name == "button2"){//color red wins on button 2
            switch (i){
                case 0:
                    print("winbtn2");
                    lowerDoor(x);
                    break;
                case 1:
                    print("no winbtn2");
                    puzzleFailCount += 1;
                    break;
                case 2:
                    print("no winbtn2");
                    puzzleFailCount += 1;
                    break;
            }
        }
        else if (hit.collider.gameObject.name == "button3"){//color white wins on button 3
            switch (i){
                case 0:
                    print("no winbtn3");
                    puzzleFailCount += 1;
                    break;
                case 1:
                    print("no winbtn3");
                    puzzleFailCount += 1;
                    break;
                case 2:
                    print("winbtn3");
                    lowerDoor(x);
                    break;
            }
        }
    }

    void lowerDoor(int x){
        GameObject door = GameObject.Find("puzzleDoor" + x.ToString());
        GameObject puzzle = GameObject.Find("colorSwitchPuzzle" + x.ToString());
        Destroy(puzzle);
        StartCoroutine(openDoor(door));
        puzzleCompleteCount += 1;
    }

    void lockHideCursorToGame(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    void freeCursorEsc(){
        if (Input.GetKeyDown("escape")){
            Cursor.lockState = CursorLockMode.None;
        }
    }

    IEnumerator openDoor(GameObject door){
        float t = 0f;
        Vector3 endPos = new Vector3(door.transform.position.x, (door.transform.position.y -3), door.transform.position.z); 
        Vector3 startPos = door.transform.position;
        while (t < 1f){
            t += Time.deltaTime * 1;
            door.transform.position = Vector3.Slerp(startPos,endPos, t);
            yield return null;
        }
    }
}