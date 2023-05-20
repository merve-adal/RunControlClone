using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Merve;

public class Level_Manager : MonoBehaviour
{
    public Button[] Butonlar;
    public int Level;
    public Sprite KilitButon;

    BellekYonetim _BellekYonetim = new BellekYonetim();
    public AudioSource ButonSes;

    public GameObject YuklemeEkrani;
    public Slider YuklemeSlider;

    void Start()
    {
        ButonSes.volume = _BellekYonetim.VeriOku_f("MenuFx");

        int mevcutLevel = _BellekYonetim.VeriOku_i("SonLevel") - 4;

        int Index = 1;
        for (int i = 0; i < Butonlar.Length; i++)
        {
            if (Index <= mevcutLevel)
            {
                Butonlar[i].GetComponentInChildren<Text>().text = Index.ToString();
                int SahneIndex = Index + 4;
                Butonlar[i].onClick.AddListener(delegate { SahneYukle(SahneIndex); });

            }
            else
            {
                Butonlar[i].GetComponent<Image>().sprite = KilitButon;
                Butonlar[i].enabled = false;
            }
            Index++;
        }
    }

    public void SahneYukle(int Index)
    {
        ButonSes.Play();
        StartCoroutine(LoadAsync(Index));
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

    public void GeriDon()
    {
        ButonSes.Play();
        SceneManager.LoadScene(0);
    }
}
