using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other){
        GameObject.Find("mazelvl").SendMessage("End");
        SceneManager.LoadScene("lvlComplete");
    }
}
