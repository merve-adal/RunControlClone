using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{
    public GameObject Saldiri_Hedefi;
    public NavMeshAgent _Navmesh;
    public Animator _Animator;
    public GameManager _Gamemanager;
    bool Saldiri_Basladimi;

    void Start()
    {

    }

    public void AnimasyonTetikle()
    {
        _Animator.SetBool("Saldir", true);
        Saldiri_Basladimi = true;
    }


    void LateUpdate()
    {
        if (Saldiri_Basladimi)
            _Navmesh.SetDestination(Saldiri_Hedefi.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakterler"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);
            _Gamemanager.YokOlmaEfektiOlustur(yeniPoz, false, true);
            gameObject.SetActive(false);
        }
    }
}
