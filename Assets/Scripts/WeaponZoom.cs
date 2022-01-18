using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;// fps: First Person 
    [SerializeField] float zoomedOutFOV = 60f; //FOV: Field of View
    [SerializeField] float zoomedInFOV = 20f;

    bool zoomedInToggle = false;

    private void Update()
    {
        //If the right the mouse button is clicked
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomedInFOV;
            }

            else
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
            }
        }
    }
}
