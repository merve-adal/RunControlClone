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
        _BellekYonetim.VeriKaydet_int("SonLevel", Level);

        int mevcutLevel = _BellekYonetim.VeriOku_i("SonLevel") - 4;

        for (int i = 0; i < Butonlar.Length; i++)
        {
            if (i + 1 <= mevcutLevel)
            {
                Butonlar[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
                //  int Index = i + 1;

            }
            else
            {
                Butonlar[i].GetComponent<Image>().sprite = KilitButon;

            }
        }
    }

    public void GeriDon()
    {
        SceneManager.LoadScene(0);
    }
}
