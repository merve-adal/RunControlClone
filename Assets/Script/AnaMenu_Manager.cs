using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Merve;


public class AnaMenu_Manager : MonoBehaviour
{
    BellekYonetim _Bellekyonetim = new BellekYonetim();
    VeriYonetimi _Veriyonetim = new VeriYonetimi();
    public GameObject CikisPaneli;
    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();
    public AudioSource ButonSes;

    void Start()
    {
        _Bellekyonetim.KontrolEtveTanimla();
        _Veriyonetim.ilkKurulumDosyaOlusturma(_ItemBilgileri);
        ButonSes.volume = _Bellekyonetim.VeriOku_f("MenuFx");
    }

    public void SahneYukle(int Index)
    {
        ButonSes.Play();
        SceneManager.LoadScene(Index);
    }

    public void Oyna()
    {
        ButonSes.Play();
        SceneManager.LoadScene(_Bellekyonetim.VeriOku_i("SonLevel"));
    }

    public void CikisButonislem(string durum)
    {
        ButonSes.Play();
        if (durum == "Evet")
            Application.Quit();
        else if (durum == "cikis")
            CikisPaneli.SetActive(true);
        else
            CikisPaneli.SetActive(false);
    }
}
