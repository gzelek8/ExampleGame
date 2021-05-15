using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int ammoAmount = 20;
    public Text currentAmmoTxt;

    private void Update()
    {
        currentAmmoTxt.text = ammoAmount.ToString();
    }
    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }
    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
    }

    public void AddCurrentAmmo(int pickUpAmmo)
    {
        ammoAmount += pickUpAmmo;
    }
    
}
