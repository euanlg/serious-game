using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returnLvlSelect : MonoBehaviour {

    public Button lvlSelectBtn;

    void Start(){
        lvlSelectBtn.onClick.AddListener(onClick);
    }

    void onClick(){
        SceneManager.LoadScene("lvlselect");
    }

}
