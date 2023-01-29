using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merve
{
    public class Matematiksel_islemler : MonoBehaviour
    {
        public static void Carpma(int GelenSayi, List<GameObject> Karakterler, Transform Pozisyon)
        {
            int DonguSayisi = (GameManager.AnlikKarakterSayisi * GelenSayi) - GameManager.AnlikKarakterSayisi;
            int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < DonguSayisi)
                {
                    if (!item.activeInHierarchy)
                    {
                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi++;

                    }
                }
                else
                {
                    sayi = 0;
                    break;
                }


            }
            GameManager.AnlikKarakterSayisi *= GelenSayi;
        }

        public static void Toplama(int GelenSayi, List<GameObject> Karakterler, Transform Pozisyon)
        {
            int sayi2 = 0;
            foreach (var item in Karakterler)
            {
                if (sayi2 < GelenSayi)
                {
                    if (!item.activeInHierarchy)
                    {
                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi2++;

                    }
                }
                else
                {
                    sayi2 = 0;
                    break;
                }


            }
            GameManager.AnlikKarakterSayisi += GelenSayi;
        }

        public static void Cikartma(int GelenSayi, List<GameObject> Karakterler)
        {
            if (GameManager.AnlikKarakterSayisi < GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarakterSayisi = 1;
            }
            else
            {
                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 != GelenSayi)
                    {
                        if (item.activeInHierarchy)
                        {
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;

                        }
                    }
                    else
                    {
                        sayi3 = 0;
                        break;
                    }

                }
                GameManager.AnlikKarakterSayisi -= GelenSayi;
            }
        }

        public static void Bolme(int GelenSayi, List<GameObject> Karakterler)
        {
            if (GameManager.AnlikKarakterSayisi <= GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarakterSayisi = 1;
            }
            else
            {
                int bolen = GameManager.AnlikKarakterSayisi / GelenSayi;

                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 != bolen)
                    {
                        if (item.activeInHierarchy)
                        {
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;

                        }
                    }
                    else
                    {
                        sayi3 = 0;
                        break;
                    }


                }

                if (GameManager.AnlikKarakterSayisi % GelenSayi == 0)
                {
                    GameManager.AnlikKarakterSayisi /= GelenSayi;
                }
                else if (GameManager.AnlikKarakterSayisi % GelenSayi == 1)
                {
                    GameManager.AnlikKarakterSayisi /= GelenSayi;
                    GameManager.AnlikKarakterSayisi++;
                }
                else if (GameManager.AnlikKarakterSayisi % GelenSayi == 2)
                {
                    GameManager.AnlikKarakterSayisi /= GelenSayi;
                    GameManager.AnlikKarakterSayisi += 2;
                }


            }
        }
    }
}
