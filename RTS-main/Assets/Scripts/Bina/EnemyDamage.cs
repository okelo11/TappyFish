using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;

    [SerializeField]
    int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Tank")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
