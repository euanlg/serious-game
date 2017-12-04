using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    public static string Name;
    public static int Age;
    public Button startBtn;
    public InputField ageFld;
    public InputField nameFld;
    public Text txt;

    void Start(){
        startBtn.onClick.AddListener(onClickStart);
    }

    void onClickStart(){

        Age = int.Parse(ageFld.text);
        if(Age >= 14){
            if (nameFld.text == ""){
                Name = "anonymous";
                SceneManager.LoadScene("lvlselect");
            }else{
                Name = nameFld.text.ToString();
                SceneManager.LoadScene("lvlselect");
            }
        }
        else{
            txt.text = "Please Enter a valid age of 14 or older";
        }
        
    }

}
