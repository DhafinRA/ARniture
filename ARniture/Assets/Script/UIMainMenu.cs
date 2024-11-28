using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button btnruangTamu;
    [SerializeField] Button btnruangMakan;
    [SerializeField] Button btnruangTidur;
    [SerializeField] Button btnDapur;

    void Start(){
        btnruangTamu.onClick.AddListener(sceneRuangTamu);
        btnruangMakan.onClick.AddListener(sceneRuangMakan);
        btnruangTidur.onClick.AddListener(sceneRuangTidur);
        btnDapur.onClick.AddListener(sceneDapur);
    }

    private void sceneRuangTamu(){
        SceneChanger.Instance.changeScene(SceneChanger.Scene.ruangTamu);
    }
    private void sceneRuangMakan(){
        SceneChanger.Instance.changeScene(SceneChanger.Scene.ruangMakan);
    }
    private void sceneRuangTidur(){
        SceneChanger.Instance.changeScene(SceneChanger.Scene.ruangTidur);
    }
    private void sceneDapur(){
        SceneChanger.Instance.changeScene(SceneChanger.Scene.Dapur);
    }
}
