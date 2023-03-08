using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Merve;


public class AnaMenu_Manager : MonoBehaviour
{
    BellekYonetim _Bellekyonetim = new BellekYonetim();
    public GameObject CikisPaneli;

    void Start()
    {
        _Bellekyonetim.KontrolEtveTanimla();
    }

    public void SahneYukle(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void Oyna()
    {
        SceneManager.LoadScene(_Bellekyonetim.VeriOku_i("SonLevel"));

    }

    public void CikisButonislem(string durum)
    {
        if (durum == "Evet")
            Application.Quit();
        else if (durum == "cikis")
            CikisPaneli.SetActive(true);
        else
            CikisPaneli.SetActive(false);
    }
}
