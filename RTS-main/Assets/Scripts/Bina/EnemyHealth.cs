using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth: MonoBehaviour 
{
    public int maxHealth;//en y�ksek can 
    public int currentHealth;//�imdiki can
    


    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int amount)//Hasar miktar�
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
