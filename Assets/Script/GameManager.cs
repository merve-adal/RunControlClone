using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject DogmaNoktasi;
    public GameObject VarisNoktasi;
    public int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))

            foreach (var item in Karakterler)
            {
                if (!item.activeInHierarchy)
                {
                    item.transform.position = DogmaNoktasi.transform.position;
                    item.SetActive(true);
                    AnlikKarakterSayisi++;
                    break;
                }
            }
    }
}
