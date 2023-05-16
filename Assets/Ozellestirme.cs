using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Merve;
using TMPro;
using UnityEngine.SceneManagement;

public class Ozellestirme : MonoBehaviour
{
    public Text PuanText;
    public GameObject[] islemPanelleri;
    public GameObject islemCanvasi;
    public GameObject[] GenelPaneller;
    public Button[] islemButonlari;
    public TextMeshProUGUI SatinAlmaText;
    int AktifislemPaneliIndex;
    [Header("-------SAPKALAR")]
    public GameObject[] Sapkalar;
    public Button[] SapkaButonlari;
    public Text SapkaText;
    [Header("-------SOPALAR")]
    public GameObject[] Sopalar;
    public Button[] SopaButonlari;
    public Text SopaText;
    [Header("-------MATERÝAL")]
    public Material[] Materyaller;
    public Material VarsayilanTema;
    public Button[] MateryalButonlari;
    public Text MaterialText;
    public SkinnedMeshRenderer _Renderer;


    int SapkaIndex = -1;
    int SopaIndex = -1;
    int MaterialIndex = -1;

    BellekYonetim _BellekYonetim = new BellekYonetim();
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    [Header("-------GENEL VERÝLER")]
    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();

    void Start()
    {
        _BellekYonetim.VeriKaydet_int("AktifSapka", -1);
        _BellekYonetim.VeriKaydet_int("AktifSopa", -1);
        _BellekYonetim.VeriKaydet_int("AktifTema", -1);
     //   _BellekYonetim.VeriKaydet_int("Puan", 6400);
        PuanText.text = _BellekYonetim.VeriOku_i("Puan").ToString();
        


      //     _VeriYonetim.Save(_ItemBilgileri);

        _VeriYonetim.Load();
        _ItemBilgileri = _VeriYonetim.ListeyiAktar();  

    }

    void DurumuKontrolEt(int Bolum,bool islem=false)
    {
        if (Bolum==0)
        {
            #region
            if (_BellekYonetim.VeriOku_i("AktifSapka") == -1)
            {
                foreach (var item in Sapkalar)
                {
                    item.SetActive(false);
                }

                SatinAlmaText.text = "SATIN AL";
                islemButonlari[0].interactable = false;
                islemButonlari[1].interactable = false;


                if (!islem)
                {
                    SapkaIndex = -1;
                    SapkaText.text = "Þapka yok";
                }               
            }
            else
            {
                SapkaIndex = _BellekYonetim.VeriOku_i("AktifSapka");
                Sapkalar[SapkaIndex].SetActive(true);
            }
            #endregion
        }
        else if (Bolum ==1)
        {
            #region
            if (_BellekYonetim.VeriOku_i("AktifSopa") == -1)
            {
                foreach (var item in Sopalar)
                {
                    item.SetActive(false);
                }

                islemButonlari[0].interactable = false;
                islemButonlari[1].interactable = false;
                SatinAlmaText.text = "SATIN AL";

                if (!islem)
                {
                    SopaIndex = -1;
                    SopaText.text = "Sopa yok";
                }
            }
            else
            {
                SopaIndex = _BellekYonetim.VeriOku_i("AktifSopa");
                Sopalar[SopaIndex].SetActive(true);
            }
            #endregion
        }else
        {
            if (_BellekYonetim.VeriOku_i("AktifTema") == -1)
            {
                if (!islem)
                {
                    SatinAlmaText.text = "SATIN AL";
                    MaterialIndex = -1;
                    MaterialText.text = "Tema yok";
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = false;
                }
                else
                {
                    Material[] mats = _Renderer.materials;
                    mats[0] = VarsayilanTema;
                    _Renderer.materials = mats;
                    SatinAlmaText.text = "SATIN AL";
                }
            }
            else
            {
                MaterialIndex = _BellekYonetim.VeriOku_i("AktifTema");
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MaterialIndex];
                _Renderer.materials = mats;
            }
        }      
    }

    public void SatinAl()
    {
        if(AktifislemPaneliIndex!=-1)
        {
            switch(AktifislemPaneliIndex)
            {
                case 0:
                    /*     Debug.Log("Bölüm no: " + AktifislemPaneliIndex + " Item Index " + SapkaIndex + "Item Ad" + _ItemBilgileri[SapkaIndex].Item_Ad); */

                    _ItemBilgileri[SapkaIndex].SatinAlmaDurumu = true;
                    _BellekYonetim.VeriKaydet_int("Puan", _BellekYonetim.VeriOku_i("Puan") - _ItemBilgileri[SapkaIndex].Puan);
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                    PuanText.text = _BellekYonetim.VeriOku_i("Puan").ToString();

                    break;
                case 1:
                    /*  Debug.Log("Bölüm no: " + AktifislemPaneliIndex + " Item Index " + SopaIndex + "Item Ad" + _ItemBilgileri[SopaIndex + 3].Item_Ad); */

                    _ItemBilgileri[SopaIndex + 3].SatinAlmaDurumu = true;
                    _BellekYonetim.VeriKaydet_int("Puan", _BellekYonetim.VeriOku_i("Puan") - _ItemBilgileri[SopaIndex + 3].Puan);
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                    PuanText.text = _BellekYonetim.VeriOku_i("Puan").ToString();

                    break;
                case 2:
                /*    Debug.Log("Bölüm no: " + AktifislemPaneliIndex + " Item Index " + MaterialIndex + "Item Ad" + _ItemBilgileri[MaterialIndex + 6].Item_Ad); */

                    _ItemBilgileri[MaterialIndex + 6].SatinAlmaDurumu = true;
                    _BellekYonetim.VeriKaydet_int("Puan", _BellekYonetim.VeriOku_i("Puan") - _ItemBilgileri[MaterialIndex + 6].Puan);
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                    PuanText.text = _BellekYonetim.VeriOku_i("Puan").ToString();

                    break;
            }
        }
    }

    public void Kaydet()
    {
        Debug.Log(AktifislemPaneliIndex);
    }

    public void Sapka_Yonbutonlari(string islem)
    {
        if (islem == "ileri")
        {

            if (SapkaIndex == -1)
            {
                SapkaIndex = 0;
                Sapkalar[SapkaIndex].SetActive(true);
                SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;

                if(!_ItemBilgileri[SapkaIndex].SatinAlmaDurumu)
                {
                    SatinAlmaText.text = _ItemBilgileri[SapkaIndex].Puan + " - SATIN AL";
                    islemButonlari[1].interactable = false;

                    if (_BellekYonetim.VeriOku_i("Puan")< _ItemBilgileri[SapkaIndex].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;
                }
                else
                {
                    SatinAlmaText.text ="SATIN AL";
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }
            }
            else
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex++;
                Sapkalar[SapkaIndex].SetActive(true);
                SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;

                if (!_ItemBilgileri[SapkaIndex].SatinAlmaDurumu)
                {
                    SatinAlmaText.text = _ItemBilgileri[SapkaIndex].Puan + " - SATIN AL";
                    islemButonlari[1].interactable = false;
                    if (_BellekYonetim.VeriOku_i("Puan") < _ItemBilgileri[SapkaIndex].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;
                }
                else
                {
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }
            }

            //-------------------------------------------------

            if (SapkaIndex == Sapkalar.Length - 1)
                SapkaButonlari[1].interactable = false;
            else
                SapkaButonlari[1].interactable = true;

            if (SapkaIndex != -1)
                SapkaButonlari[0].interactable = true;

        }
        else
        {
            if (SapkaIndex != -1)
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex--;
                if (SapkaIndex != -1)
                {
                    Sapkalar[SapkaIndex].SetActive(true);
                    SapkaButonlari[0].interactable = true;
                    SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;

                    if (!_ItemBilgileri[SapkaIndex].SatinAlmaDurumu)
                    {
                        SatinAlmaText.text = _ItemBilgileri[SapkaIndex].Puan + " - SATIN AL";
                        islemButonlari[1].interactable = false;
                        if (_BellekYonetim.VeriOku_i("Puan") < _ItemBilgileri[SapkaIndex].Puan)
                            islemButonlari[0].interactable = false;
                        else
                            islemButonlari[0].interactable = true;
                    }
                    else
                    {
                        SatinAlmaText.text = "SATIN AL";
                        islemButonlari[0].interactable = false;
                        islemButonlari[1].interactable = true;
                    }
                }
                else
                {
                    SapkaButonlari[0].interactable = false;
                    SapkaText.text = "Þapka yok";
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                }

            }
            else
            {
                SapkaButonlari[0].interactable = false;
                SapkaText.text = "Þapka yok";
                SatinAlmaText.text = "SATIN AL";
                islemButonlari[0].interactable = false;
            }

            //-------------------------------------------------

            if (SapkaIndex != Sapkalar.Length - 1)
                SapkaButonlari[1].interactable = true;
        }
    }

    public void Sopa_Yonbutonlari(string islem)
    {
        if (islem == "ileri")
        {

            if (SopaIndex == -1)
            {
                SopaIndex = 0;
                Sopalar[SopaIndex].SetActive(true);
                SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;

                if (!_ItemBilgileri[SopaIndex + 3].SatinAlmaDurumu)
                {
                    SatinAlmaText.text = _ItemBilgileri[SopaIndex + 3].Puan + " - SATIN AL";

                    islemButonlari[1].interactable = false;
                    if (_BellekYonetim.VeriOku_i("Puan") < _ItemBilgileri[SopaIndex + 3].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;
                }
                else
                {
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }
            }
            else
            {
                Sopalar[SopaIndex].SetActive(false);
                SopaIndex++;
                Sopalar[SopaIndex].SetActive(true);
                SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;

                if (!_ItemBilgileri[SopaIndex + 3].SatinAlmaDurumu)
                {
                    SatinAlmaText.text = _ItemBilgileri[SopaIndex + 3].Puan + " - SATIN AL";
                    islemButonlari[1].interactable = false;
                    if (_BellekYonetim.VeriOku_i("Puan") < _ItemBilgileri[SopaIndex + 3].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;
                }
                else
                {
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }
            }

            //-------------------------------------------------

            if (SopaIndex == Sopalar.Length - 1)
                SopaButonlari[1].interactable = false;
            else
                SopaButonlari[1].interactable = true;

            if (SopaIndex != -1)
                SopaButonlari[0].interactable = true;

        }
        else
        {
            if (SopaIndex != -1)
            {
                Sopalar[SopaIndex].SetActive(false);
                SopaIndex--;
                if (SopaIndex != -1)
                {
                    Sopalar[SopaIndex].SetActive(true);
                    SopaButonlari[0].interactable = true;
                    SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;

                    if (!_ItemBilgileri[SopaIndex + 3].SatinAlmaDurumu)
                    {
                        SatinAlmaText.text = _ItemBilgileri[SopaIndex + 3].Puan + " - SATIN AL";
                        islemButonlari[1].interactable = false;
                        if (_BellekYonetim.VeriOku_i("Puan") < _ItemBilgileri[SopaIndex + 3].Puan)
                            islemButonlari[0].interactable = false;
                        else
                            islemButonlari[0].interactable = true;
                    }
                    else
                    {
                        SatinAlmaText.text = "SATIN AL";
                        islemButonlari[0].interactable = false;
                        islemButonlari[1].interactable = true;
                    }
                }
                else
                {
                    SopaButonlari[0].interactable = false;
                    SopaText.text = "Sopa yok";
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                }

            }
            else
            {
                SopaButonlari[0].interactable = false;
                SopaText.text = "Sopa yok";
                SatinAlmaText.text = "SATIN AL";
                islemButonlari[0].interactable = false;
            }

            //-------------------------------------------------

            if (SopaIndex != Sopalar.Length - 1)
                SopaButonlari[1].interactable = true;
        }
    }

    public void Material_Yonbutonlari(string islem)
    {
        if (islem == "ileri")
        {

            if (MaterialIndex == -1)
            {
                MaterialIndex = 0;
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MaterialIndex];
                _Renderer.materials = mats;

                MaterialText.text = _ItemBilgileri[MaterialIndex + 6].Item_Ad;

                if (!_ItemBilgileri[MaterialIndex + 6].SatinAlmaDurumu)
                {
                    SatinAlmaText.text = _ItemBilgileri[MaterialIndex + 6].Puan + " - SATIN AL";
                    islemButonlari[1].interactable = false;
                    if (_BellekYonetim.VeriOku_i("Puan") < _ItemBilgileri[MaterialIndex + 6].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;
                }
                else
                {
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }
            }
            else
            {
                MaterialIndex++;
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MaterialIndex];
                _Renderer.materials = mats;

                MaterialText.text = _ItemBilgileri[MaterialIndex + 6].Item_Ad;

                if (!_ItemBilgileri[MaterialIndex + 6].SatinAlmaDurumu)
                {
                    SatinAlmaText.text = _ItemBilgileri[MaterialIndex + 6].Puan + " - SATIN AL";
                    islemButonlari[1].interactable = false;
                    if (_BellekYonetim.VeriOku_i("Puan") < _ItemBilgileri[MaterialIndex + 6].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;
                }
                else
                {
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }
            }

            //-------------------------------------------------

            if (MaterialIndex == Materyaller.Length - 1)
                MateryalButonlari[1].interactable = false;
            else
                MateryalButonlari[1].interactable = true;

            if (MaterialIndex != -1)
                MateryalButonlari[0].interactable = true;

        }
        else
        {
            if (MaterialIndex != -1)
            {
                MaterialIndex--;
                if (MaterialIndex != -1)
                {
                    Material[] mats = _Renderer.materials;
                    mats[0] = Materyaller[MaterialIndex];
                    _Renderer.materials = mats;

                    MateryalButonlari[0].interactable = true;
                    MaterialText.text = _ItemBilgileri[MaterialIndex + 6].Item_Ad;

                    if (!_ItemBilgileri[MaterialIndex + 6].SatinAlmaDurumu)
                    {
                        SatinAlmaText.text = _ItemBilgileri[MaterialIndex + 6].Puan + " - SATIN AL";
                        islemButonlari[1].interactable = false;
                        if (_BellekYonetim.VeriOku_i("Puan") < _ItemBilgileri[MaterialIndex + 6].Puan)
                            islemButonlari[0].interactable = false;
                        else
                            islemButonlari[0].interactable = true;
                    }
                    else
                    {
                        SatinAlmaText.text = "SATIN AL";
                        islemButonlari[0].interactable = false;
                        islemButonlari[1].interactable = true;
                    }
                }
                else
                {
                    Material[] mats = _Renderer.materials;
                    mats[0] = VarsayilanTema;
                    _Renderer.materials = mats;

                    MateryalButonlari[0].interactable = false;
                    MaterialText.text = "Tema yok";
                    SatinAlmaText.text = "SATIN AL";
                    islemButonlari[0].interactable = false;
                }

            }
            else
            {
                Material[] mats = _Renderer.materials;
                mats[0] = VarsayilanTema;
                _Renderer.materials = mats;

                MateryalButonlari[0].interactable = false;
                MaterialText.text = "Tema yok";
                SatinAlmaText.text = "SATIN AL";
                islemButonlari[0].interactable = false;
            }

            //-------------------------------------------------

            if (MaterialIndex != Materyaller.Length - 1)
                MateryalButonlari[1].interactable = true;
        }
    }

    public void islemPaneliCikart(int Index)
    {
        DurumuKontrolEt(Index);
        GenelPaneller[0].SetActive(true);
        AktifislemPaneliIndex = Index;
        islemPanelleri[Index].SetActive(true);
        GenelPaneller[1].SetActive(true);
        islemCanvasi.SetActive(false);      
    }

    public void GeriDon()
    {
        GenelPaneller[0].SetActive(false);
        islemCanvasi.SetActive(true);
        GenelPaneller[1].SetActive(false);
        islemPanelleri[AktifislemPaneliIndex].SetActive(false);
        DurumuKontrolEt(AktifislemPaneliIndex,true);
        AktifislemPaneliIndex = -1;
    }

    public void AnaMenuyeDon()
    {
        _VeriYonetim.Save(_ItemBilgileri);
        SceneManager.LoadScene(0);
    }
}
