using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth: MonoBehaviour 
{
    public int maxHealth;//en yüksek can 
    public int currentHealth;//þimdiki can
    


    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int amount)//Hasar miktarý
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
