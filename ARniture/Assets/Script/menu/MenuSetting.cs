using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuSetting : MonoBehaviour
{
    [Header("Menu Utama")]
    [SerializeField] Image bg;
    [SerializeField] GameObject[] MenuList;
    [SerializeField] RectTransform panelmenu;
    [SerializeField] GameObject[] panelList;

    [Header("Menu Kategori")]
    [SerializeField] TMP_Text cat_kat;
    [SerializeField] TMP_Text cat_desc;
    [SerializeField] TMP_Text[] cat_product;

    [Header("Menu Detail")]
    [SerializeField] Image det_img;
    [SerializeField] TMP_Text det_name;
    [SerializeField] TMP_Text det_desc;
    [SerializeField] TMP_Text det_cat;

    [Header("Content")]
    [SerializeField] string[] kategori;
    [TextArea]
    [SerializeField] string[] deskripsi;
    [SerializeField] string[] product;
    [TextArea]
    [SerializeField] string[] product_desc;
    [SerializeField] Sprite[] product_img;

    Vector2 startpos;
    Vector2 endpos;
    
    float movespd = 10.0f;
    bool ismoving=false;

    TextAsset txtprod;
    TextAsset txtdet;

    void Start()
    {
        bg.color = Color.white;
        MenuList[0].SetActive(true);
        MenuList[1].SetActive(false);
        MenuList[2].SetActive(false);

        panelList[0].SetActive(false);
        panelList[1].SetActive(false);
        panelList[2].SetActive(false);

        startpos = panelmenu.anchoredPosition;
        endpos = startpos;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ismoving)
        {
            panelmenu.anchoredPosition = Vector2.Lerp(panelmenu.anchoredPosition, endpos, Time.deltaTime * movespd);

            // Jika objek sudah dekat dengan target, hentikan pergerakan
            if (Vector2.Distance(panelmenu.anchoredPosition, endpos) < 0.1f)
            {
                panelmenu.anchoredPosition = endpos; // Pastikan posisi akhir tepat
                ismoving = false; // Hentikan pergerakan
            }
        }
    }

    void catClick()
    {
        MenuList[0].SetActive(false);
        MenuList[1].SetActive(true);
    }
    void productChange()
    {
        //prod
        txtprod = Resources.Load<TextAsset>(cat_kat.text + "/Product");
        if (txtprod != null)
        {
            product = txtprod.text.Split('\n');
        }
        else
        {
            Debug.LogError("File tidak ditemukan di folder Resources!");
        }
        //prod_det
        txtdet = Resources.Load<TextAsset>(cat_kat.text + "/Product_Detail");
        if (txtdet != null)
        {
            product_desc = txtdet.text.Split('\n');
        }
        else
        {
            Debug.LogError("File tidak ditemukan di folder Resources!");
        }
        //prod_img
        product_img = Resources.LoadAll<Sprite>(cat_kat.text + "/Image");
        if (product_img.Length > 0)
        {
            Debug.Log("Success Load Sprite");
        }
        else
        {
            Debug.LogError("Sprite Tidak Ditemukan!");
        }
    }

    void changeTxtColor(string hexcol)
    {
        if (ColorUtility.TryParseHtmlString(hexcol, out Color newColor))
        {
            // Mengubah warna teks
            cat_kat.color = newColor;
        }
        else
        {
            Debug.LogError("Invalid Hex Color: " + hexcol);
        }
    }
    public void rTamuClick()
    {
        catClick();
        cat_kat.text = kategori[0];
        changeTxtColor("#F36666");
        cat_desc.text = deskripsi[0];
        productChange();
        for (int i = 0;i<cat_product.Length;i++)
        {
            cat_product[i].text = product[i];
        }
    }
    public void rKerjaClick()
    {
        catClick();
        cat_kat.text = kategori[1];
        changeTxtColor("#49B4F3");
        cat_desc.text = deskripsi[1];
        productChange();
        for (int i = 0; i < cat_product.Length; i++)
        {
            cat_product[i].text = product[i];
        }
    }
    public void rTidurClick()
    {
        catClick();
        cat_kat.text = kategori[2];
        changeTxtColor("#FFDA86");
        cat_desc.text = deskripsi[2];
        productChange();
        for (int i = 0; i < cat_product.Length; i++)
        {
            cat_product[i].text = product[i];
        }
    }
    public void rDapurClick()
    {
        catClick();
        cat_kat.text = kategori[3];
        changeTxtColor("#4BD984");
        cat_desc.text = deskripsi[3];
        productChange();
        for (int i = 0; i < cat_product.Length; i++)
        {
            cat_product[i].text = product[i];
        }
    }
    public void catBackClick()
    {
        MenuList[0].SetActive(true);
        MenuList[1].SetActive(false);
    }
    void detClick()
    {
        MenuList[1].SetActive(false);
        MenuList[2].SetActive(true);
    }
    public void detProductClick(int a)
    {
        detClick();
        switch (a)
        {
            case 0:
                bg.color = Color.cyan; break;
            case 1:
                bg.color = Color.green; break;
            case 2:
                bg.color = Color.blue; break;
            case 3:
                bg.color = Color.red; break;
            case 4:
                bg.color = Color.magenta; break;
            case 5:
                bg.color = Color.yellow; break;
            default: bg.color = Color.gray; break;
        }
        if (a > product_img.Length - 1)
        {
            det_img.sprite = Resources.Load<Sprite>("image_not_found");
        }
        else
        {
            det_img.sprite = product_img[a];
        }

        det_name.text = cat_product[a].text;
        det_desc.text = product_desc[a];
        det_cat.text = "Ruang "+ cat_kat.text;
        DataGlobal.Kategori = cat_kat.text;
        DataGlobal.Produk = det_name.text;
        DataGlobal.noProduct = a;
    }
    public void arModeClick()
    {
        SceneManager.LoadScene(1);
    }
    public void detBackClick()
    {
        bg.color = Color.white;
        MenuList[1].SetActive(true);
        MenuList[2].SetActive(false);
    }

    public void homeMenuClick()
    {
        endpos = new Vector2(0f, panelmenu.anchoredPosition.y);  // Set target posisi baru
        ismoving = true;
    }
    
    public void backMenuClick()
    {
        endpos = startpos;  // Set target posisi ke posisi awal
        ismoving = true;
    }

    public void aboutAppOpen()
    {
        panelList[0].SetActive(true);
    }
    public void aboutAppClose()
    {
        panelList[0].SetActive(false);
    }
    public void tutorialOpen()
    {
        panelList[1].SetActive(true);
    }
    public void tutorialClose()
    {
        panelList[1].SetActive(false);
    }
    public void aboutUsOpen()
    {
        panelList[2].SetActive(true);
    }
    public void aboutUsClose()
    {
        panelList[2].SetActive(false);
    }
    public void ezLink(string username)
    {
        Application.OpenURL("https://www.linkedin.com/in/" + username);
    }
    public void exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Berhenti dari mode Play di editor
#else
            Application.Quit(); // Menutup aplikasi jika sudah di build
#endif
    }

    public static class DataGlobal
    {
        public static string Kategori;
        public static string Produk;
        public static int noProduct;
    }

}
