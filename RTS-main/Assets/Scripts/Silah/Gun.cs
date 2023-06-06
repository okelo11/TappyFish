using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Gun : MonoBehaviour
{
    RaycastHit hit;
    public GameObject mermiCikisNoktasi;
    public ParticleSystem particle;
    //Mermi �zelli�i
    public int hasar;
    public float aral�k;
     float sayac;
    public float zaman;
    public LayerMask lm;
    public NavMeshAgent agent;
    public Transform parentTransform;
    void Update()
    {
        HasarVer();
        
    }
    void HasarVer()
    {
        var enemies = Physics.OverlapSphere(transform.position, aral�k, lm);
        Debug.Log(enemies.Length);
        if (enemies.Length >= 1)
        {
            agent.updateRotation = false;
            Debug.Log(enemies);
            parentTransform.LookAt(enemies[0].transform);
            sayac += Time.deltaTime;
            if (sayac >= zaman)
            {
                particle.Play();
                Debug.Log("dmg atildi");
                enemies[0].GetComponent<EnemyHealth>().TakeDamage(hasar);
                sayac = 0f;
            }
        }
        else
        {
            agent.updateRotation = true;
        }
        
    }





}
