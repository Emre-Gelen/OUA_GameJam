using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yonetici : MonoBehaviour
{
    public static yonetici instance = null;

    private static bool _isWordleStarted;

    public string[] sozluk;
    public Text puan_txt;
    public bool tiklandi = false;
    public GameObject bitti_panel;
    public GameObject GameCanvas;
    
    List<GameObject> isaretli_butonlar;
    string kelime= null;
    int puan = 0;
    int bulunan_kelime_sayisi = 0;


    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static void StartWordle()
    {
        if (!_isWordleStarted)
        {
            _isWordleStarted = true;
            instance.isaretli_butonlar = new();
            instance.GameCanvas.SetActive(true);
        }
    }
    
    public void isaretli_buton_olustur(GameObject buton)
    {
        isaretli_butonlar.Add(buton);
        
        kelime = null;
        
        foreach (GameObject butonlar in isaretli_butonlar)
        {
            kelime = kelime + butonlar.name;
            puan_txt.text = kelime;
        }
    }
    
    void Update()
    {
        if (!_isWordleStarted)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            tiklandi = true;
        }
        
        
        if (Input.GetMouseButtonUp(0))
        {
            tiklandi = false;
            
            yazi_olustur();
            
            puan_txt.text = puan.ToString();
        }
    }
    
    void yazi_olustur()
    {
        foreach (string kelimeler in sozluk)
        {
            if (kelimeler.Equals(kelime, System.StringComparison.OrdinalIgnoreCase))
            {
                puan += 100;
                bulunan_kelime_sayisi++;

                foreach (GameObject buton in isaretli_butonlar)
                {
                    buton.GetComponent<buton>().yok_ol = true;

                }
            }

        }
        
        isaretli_butonlar.Clear();
        kelime = null;
        
        if (bulunan_kelime_sayisi == sozluk.Length)
        {
            bitti_panel.SetActive(true);
            instance.GameCanvas.SetActive(false);
            GameManager.AddScore(puan);
            _isWordleStarted = false;
        }
    }
}
