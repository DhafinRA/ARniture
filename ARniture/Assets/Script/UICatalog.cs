using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICatalog : MonoBehaviour
{
    [SerializeField] Button btnBack;
    [SerializeField] Button btnBarang1;
    [SerializeField] Button btnBarang2;
    [SerializeField] Button btnBarang3;
    [SerializeField] Button btnBarang4;

    void Start(){
        btnBack.onClick.AddListener(sceneMainMenu);
        btnBarang1.onClick.AddListener(sceneInfoBarang);
        btnBarang2.onClick.AddListener(sceneInfoBarang);
        btnBarang3.onClick.AddListener(sceneInfoBarang);
        btnBarang4.onClick.AddListener(sceneInfoBarang);
    }

    private void sceneMainMenu(){
        SceneChanger.Instance.loadMainMenu();
    }

    private void sceneInfoBarang(){
        SceneChanger.Instance.changeScene(SceneChanger.Scene.infoBarang);
    }
}
