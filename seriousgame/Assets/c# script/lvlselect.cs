using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lvlselect : MonoBehaviour {

    public static string difficultySelect;

    public Button easyBtn;
    public Button mediumBtn;

    void Start(){
        charactercontroler.puzzleFailCount = 0;
        charactercontroler.puzzleCompleteCount = 0;
        difficultySelect = "";

        easyBtn.onClick.AddListener(onClickEasy);
        mediumBtn.onClick.AddListener(onClickMedium);
    }

    void onClickEasy(){
        difficultySelect = "Easy";
        SceneManager.LoadScene("mazelvl");
    }

    void onClickMedium(){
        difficultySelect = "Medium";
        SceneManager.LoadScene("mazelvl");
    }
}

