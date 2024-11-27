using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MenuSetting : MonoBehaviour
{
    [Header("Menu Utama")]
    [SerializeField] Image bg;
    [SerializeField] GameObject[] MenuList;
    [SerializeField] RectTransform panelmenu;

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
    public string[] kategori;
    [TextArea]
    public string[] deskripsi;
    public string[] product;
    [TextArea]
    public string[] product_desc;

    Vector2 startpos;
    Vector2 endpos;
    
    float movespd = 10.0f;
    bool ismoving=false;

    void Start()
    {
        bg.color = Color.white;
        MenuList[0].SetActive(true);
        MenuList[1].SetActive(false);
        MenuList[2].SetActive(false);

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
        if(cat_kat.text == kategori[0])
        {
            product[0] = "Sofa";
            product[1] = "Meja";
            product[2] = "Rak Tv";
            product[3] = "Karpet";
            product[4] = "Lemari Hias";
            product[5] = "Kursi";

            product_desc[0] = "Perabot duduk dengan bantalan empuk, biasanya dilapisi kain atau kulit, yang dirancang untuk kenyamanan di ruang tamu atau ruang keluarga. Sofa tersedia dalam berbagai ukuran dan gaya, seperti sofa dua tempat duduk, sectional, atau sofa sudut.";
            product_desc[1] = "Furnitur dengan permukaan datar yang berfungsi untuk bekerja, makan, atau meletakkan benda. Meja bisa berbentuk persegi, bulat, atau persegi panjang, dan sering dilengkapi dengan kaki penyangga dari kayu, logam, atau bahan lainnya.";
            product_desc[2] = "Furnitur rendah yang dirancang untuk menopang televisi dan perangkat hiburan lainnya, seperti konsol game, speaker, atau pemutar DVD. Rak TV biasanya memiliki ruang penyimpanan tambahan berupa laci atau rak terbuka.";
            product_desc[3] = "Penutup lantai yang terbuat dari kain tenun atau bahan sintetis, berfungsi untuk menambah kenyamanan dan estetika ruangan. Karpet tersedia dalam berbagai motif, warna, dan ukuran untuk disesuaikan dengan dekorasi ruangan.";
            product_desc[4] = "Lemari dengan desain terbuka atau tertutup yang digunakan untuk memajang barang dekoratif, koleksi, atau barang berharga. Biasanya dilengkapi dengan rak kaca atau kayu dan terkadang memiliki pencahayaan interior untuk menonjolkan isinya.";
            product_desc[5] = "Furnitur untuk duduk dengan desain yang bervariasi, mulai dari kursi makan, kursi kerja, hingga kursi santai. Kursi dapat terbuat dari berbagai bahan, seperti kayu, logam, atau plastik, dengan atau tanpa bantalan.";
        }
        else if (cat_kat.text == kategori[1])
        {
            product[0] = "Meja Makan";
            product[1] = "Kursi Makan";
            product[2] = "Rak Penyimpanan";
            product[3] = "Taplak Meja";
            product[4] = "Piring";
            product[5] = "Gelas";

            product_desc[0] = kategori[1] + "1";
            product_desc[1] = kategori[1] + "2";
            product_desc[2] = kategori[1] + "3";
            product_desc[3] = kategori[1] + "4";
            product_desc[4] = kategori[1] + "5";
            product_desc[5] = kategori[1] + "6";
        }
        else if (cat_kat.text == kategori[2])
        {
            product[0] = "Kasur";
            product[1] = "Lemari";
            product[2] = "Nakas";
            product[3] = "Meja Belajar";
            product[4] = "Rak";
            product[5] = "Lampu Belajar";

            product_desc[0] = kategori[2] + "1";
            product_desc[1] = kategori[2] + "2";
            product_desc[2] = kategori[2] + "3";
            product_desc[3] = kategori[2] + "4";
            product_desc[4] = kategori[2] + "5";
            product_desc[5] = kategori[2] + "6";
        }
        else if (cat_kat.text == kategori[3])
        {
            product[0] = "Kabinet Dapur";
            product[1] = "Meja Dapur";
            product[2] = "Rak Piring";
            product[3] = "Rak Gantung";
            product[4] = "Rak Anggur";
            product[5] = "Lemari Penyimpanan";

            product_desc[0] = kategori[3] + "1";
            product_desc[1] = kategori[3] + "2";
            product_desc[2] = kategori[3] + "3";
            product_desc[3] = kategori[3] + "4";
            product_desc[4] = kategori[3] + "5";
            product_desc[5] = kategori[3] + "6";
        }
        else
        {
            for (int i = 0; i < product.Length; i++)
            {
                product[i] = i.ToString();
                product_desc[i] = "desc"+i.ToString();
            }
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
    public void rMakanClick()
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
        det_name.text = cat_product[a].text;
        det_desc.text = product_desc[a];
        det_cat.text = "Ruang "+ cat_kat.text;
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

    public void exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Berhenti dari mode Play di editor
#else
            Application.Quit(); // Menutup aplikasi jika sudah di build
#endif
    }
}
