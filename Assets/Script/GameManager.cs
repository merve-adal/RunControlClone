using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merve;

public class GameManager : MonoBehaviour
{


    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;
    public List<GameObject> Karakterler;

    void Start()
    {

    }


    void Update()
    {
      
    }

    public void AdamYonetimi(string islemturu, int GelenSayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":
                Matematiksel_islemler.Carpma(GelenSayi, Karakterler, Pozisyon);
                break;

            case "Toplama":
                Matematiksel_islemler.Toplama(GelenSayi, Karakterler, Pozisyon);
                break;


            case "Cikartma":
                Matematiksel_islemler.Cikartma(GelenSayi, Karakterler);
                break;

            case "Bolme":
                Matematiksel_islemler.Bolme(GelenSayi, Karakterler);
                break;
        }
    }
}
