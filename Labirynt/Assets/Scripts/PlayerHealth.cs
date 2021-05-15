using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float hitPoints = 100f;
    public void TakeDemage(float demage)
    {
        hitPoints -= demage;
        if (hitPoints <= 0)
        {
            Debug.Log("Dead");
        }
    }
}
