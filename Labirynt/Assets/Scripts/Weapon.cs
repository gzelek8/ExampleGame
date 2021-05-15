using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera FPScamera;
    public float range = 100f;
    public ParticleSystem muzzleFLash;
    public float damage = 25f;
    bool canShoot = true;
    public Ammo ammoSlot;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canShoot)
            {
                StartCoroutine("Shoot");
            }
        }
    }

    private IEnumerator Shoot()
    {
        
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            ProcessRaycast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo();
        }
        
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFLash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(
                        FPScamera.transform.position,
                        FPScamera.transform.forward,
                        out hit,
                        range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
        }
    }
}
