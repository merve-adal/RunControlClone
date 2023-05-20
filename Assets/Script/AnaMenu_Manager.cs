using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Merve;


public class AnaMenu_Manager : MonoBehaviour
{
    BellekYonetim _Bellekyonetim = new BellekYonetim();
    VeriYonetimi _Veriyonetim = new VeriYonetimi();
    public GameObject CikisPaneli;
    public List<ItemBilgileri> _Varsayilan_ItemBilgileri = new List<ItemBilgileri>();
    public AudioSource ButonSes;
    public GameObject YuklemeEkrani;
    public Slider YuklemeSlider;

    void Start()
    {
        _Bellekyonetim.KontrolEtveTanimla();
        _Veriyonetim.ilkKurulumDosyaOlusturma(_Varsayilan_ItemBilgileri);
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

        StartCoroutine(LoadAsync(_Bellekyonetim.VeriOku_i("SonLevel")));
    }

    IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        YuklemeEkrani.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            YuklemeSlider.value = progress;
            yield return null;
        }
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
