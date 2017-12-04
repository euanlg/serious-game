using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class retryLvl : MonoBehaviour {

    public Button retryBtn;

    void Start(){
        retryBtn.onClick.AddListener(onClick);
    }

    void onClick(){
        SceneManager.LoadScene("mazelvl");
    }
}
