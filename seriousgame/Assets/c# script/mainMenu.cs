using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    public static int Age;
    public Button startBtn;
    public InputField ageFld;

    void Start(){
        startBtn.onClick.AddListener(onClickStart);
    }

    void onClickStart(){
        Age = int.Parse(ageFld.text);
        SceneManager.LoadScene("lvlselect");
    }

}
