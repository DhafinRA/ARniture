using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class tes : MonoBehaviour
{
    [SerializeField] TMP_Text produk;
    [SerializeField] ContentPositioningBehaviour planeFinder;
    [SerializeField] GameObject[] prefabAR;
    [SerializeField] AnchorBehaviour anchorStage;

    string path = MenuSetting.DataGlobal.Kategori + "/3D/";
    int id = MenuSetting.DataGlobal.noProduct;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Data Global Kategori: " + MenuSetting.DataGlobal.Kategori);
        Debug.Log("Data Global Produk: " + MenuSetting.DataGlobal.Produk);
        Debug.Log("Data Global NoProduk: " + MenuSetting.DataGlobal.noProduct);
        
        produk.text = MenuSetting.DataGlobal.Produk;
        prefabAR = Resources.LoadAll<GameObject>(path);
        if(prefabAR != null)
        {
            Debug.Log("Prefab berhasil diambil: " + MenuSetting.DataGlobal.Produk);
            Instantiate(prefabAR[id], new Vector3(0, 0, 0), Quaternion.identity);
            anchorStage = FindObjectOfType<AnchorBehaviour>();
            planeFinder.AnchorStage = anchorStage;
        }
        else
        {
            Debug.Log("Prefab gagal diambil: " +  MenuSetting.DataGlobal.Produk);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backClick()
    {
        SceneManager.LoadScene(0);
    }
}
