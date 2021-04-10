using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    public Camera fpsCamera;
    public float zoomedOutFOV = 60f;
    public float zoomedInFOV = 20f;
    bool isZoomed = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isZoomed == false)
            {
                isZoomed = true;
                fpsCamera.fieldOfView = zoomedInFOV;
            }
            else
            {
                isZoomed = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
            }
        }
    }
}
