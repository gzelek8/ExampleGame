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
            if (GetComponent<EnemyAI>().isAlive)
            {
                GetComponent<EnemyAI>().isAlive = false;
                StartCoroutine("Die");
            }
        }
    }

    IEnumerator Die()
    {
        GetComponent<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
