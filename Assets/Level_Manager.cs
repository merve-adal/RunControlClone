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

    void Start()
    {

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
      SceneManager.LoadScene(Index);
    }

    public void GeriDon()
    {
        SceneManager.LoadScene(0);
    }
}
