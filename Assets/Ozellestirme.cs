using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Merve;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Ozellestirme : MonoBehaviour
{
    public Text PuanText;
    public Text SapkaText;
    [Header("SAPKALAR")]
    public GameObject[] Sapkalar;
    public Button[] SapkaButonlari;
    [Header("SOPALAR")]
    public GameObject[] Sopalar;
    [Header("MATERÝAL")]
    public Material[] Materyaller;


    int SapkaIndex = -1;

    BellekYonetim _BellekYonetim = new BellekYonetim();

    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();

    void Start()
    {
        _BellekYonetim.VeriKaydet_int("AktifSapka", -1);

        if (_BellekYonetim.VeriOku_i("AktifSapka") == -1)
        {
            foreach (var item in Sapkalar)
            {
                item.SetActive(false);
            }
            SapkaIndex = -1;
            SapkaText.text = "Þapka yok";
        }
        else
        {
            SapkaIndex = _BellekYonetim.VeriOku_i("AktifSapka");
            Sapkalar[SapkaIndex].SetActive(true);
        }

        Load();
       // Save();
    }

    public void Save()
    {
        _ItemBilgileri[1].SatinAlmaDurumu = false;
        _ItemBilgileri.Add(new ItemBilgileri());
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/ItemVerileri.gd");
        bf.Serialize(file, _ItemBilgileri);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/ItemVerileri.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ItemVerileri.gd", FileMode.Open);
            _ItemBilgileri = (List<ItemBilgileri>)bf.Deserialize(file);
            file.Close();

            Debug.Log(_ItemBilgileri[1].SatinAlmaDurumu);
        }
    }

    public void Sapka_Yonbutonlari(string islem)
    {
        if (islem == "ileri")
        {

            if (SapkaIndex == -1)
            {
                SapkaIndex = 0;
                Sapkalar[SapkaIndex].SetActive(true);
            }
            else
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex++;
                Sapkalar[SapkaIndex].SetActive(true);
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
                }
                else
                {
                    SapkaButonlari[0].interactable = false;
                }


            }
            else
            {
                SapkaButonlari[0].interactable = false;
            }

            //-------------------------------------------------

            if (SapkaIndex != Sapkalar.Length - 1)
                SapkaButonlari[1].interactable = true;
        }
    }
}
