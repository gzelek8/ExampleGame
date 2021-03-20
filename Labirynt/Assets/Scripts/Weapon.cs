using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera FPScamera;
    public float range = 100f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(
                        FPScamera.transform.position,
                        FPScamera.transform.forward,
                        out hit,
                        range);
        Debug.Log(hit.transform.name);
    }
}
