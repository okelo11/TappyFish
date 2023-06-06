using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    NavMeshAgent agent;
    Transform mevcutHedef;
    public GameObject isik;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (mevcutHedef != null)
        {
            agent.destination = mevcutHedef.position;
        }
    }


    public void HareketBirimi(Vector3 hareket)
    {
        mevcutHedef = null;
        agent.destination = hareket;
    }

    public void SecimiAyarla(bool secilimi)
    {
        //transform.Find("Iþýk").gameObject.SetActive(secilimi);
        //var x = GameObject.Find("Iþýk");
        
        //x.SetActive(secilimi);
        isik.SetActive(secilimi);
    }

    public void YeniHedefBelirle(Transform bina)
    {
        mevcutHedef = bina;
    }
}
