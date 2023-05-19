using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Merve;

public class Ayarlar_Manager : MonoBehaviour
{
    public AudioSource ButonSes;
    public Slider MenuSes;
    public Slider MenuFx;
    public Slider OyunSes;
    BellekYonetim _BellekYonetim = new BellekYonetim();

    void Start()
    {
        ButonSes.volume = _BellekYonetim.VeriOku_f("MenuFx");

        MenuSes.value = _BellekYonetim.VeriOku_f("MenuSes");
        MenuFx.value = _BellekYonetim.VeriOku_f("MenuFx");
        OyunSes.value = _BellekYonetim.VeriOku_f("OyunSes");
    }

    public void SesAyarla(string HangiAyar)
    {
        switch(HangiAyar)
        {
            case "menuses":
                _BellekYonetim.VeriKaydet_float("MenuSes", MenuSes.value);
                break;

            case "menufx":
                _BellekYonetim.VeriKaydet_float("MenuFx", MenuFx.value);
                break;

            case "oyunses":
                _BellekYonetim.VeriKaydet_float("OyunSes", OyunSes.value);
                break;
        }
    }

    public void GeriDon()
    {
        ButonSes.Play();
        SceneManager.LoadScene(0);
    }

    public void DilDegistir()
    {
        ButonSes.Play();
    }
}
