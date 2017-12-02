using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    public Button startBtn;

    void Start(){
        startBtn.onClick.AddListener(onClickStart);
    }

    void onClickStart(){
        SceneManager.LoadScene("lvlselect");
    }

}
