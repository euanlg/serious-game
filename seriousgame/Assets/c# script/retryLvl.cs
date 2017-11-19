using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class retryLvl : MonoBehaviour {

    public Button yourButton;

    void Start(){
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
    }

    void onClick(){
        SceneManager.LoadScene("mazelvl");
    }
}
