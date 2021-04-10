using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float healthPoints = 100f;
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
