using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;

    private void Awake(){
        Instance = this;
    }

    public enum Scene{
        mainMenu,
        ruangTamu,
        ruangMakan,
        ruangTidur,
        Dapur,
        infoBarang
    }

    public void changeScene(Scene newScene){
        SceneManager.LoadScene(newScene.ToString());
    } 

    public void loadMainMenu(){
        SceneManager.LoadScene(Scene.mainMenu.ToString());
    }

    
}
