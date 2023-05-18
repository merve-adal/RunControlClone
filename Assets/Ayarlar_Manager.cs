using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ayarlar_Manager : MonoBehaviour
{
    public AudioSource ButonSes;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GeriDon()
    {
        ButonSes.Play();
        SceneManager.LoadScene(0);
    }

    public void DilDegistir()
    {
        ButonSes.Play();
    }
}
