using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;// fps: First Person 
    [SerializeField] RigidbodyFirstPersonController fpsController;

    [SerializeField] float zoomedOutFOV = 60f; //FOV: Field of View
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;// Mouse sensitivity decreses in zoom state

    bool zoomedInToggle = false;

    private void Update()
    {
        //If the right the mouse button is clicked
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                ZoomIn();
            }

            else
            {
                ZoomOut();
            }
        }
    }

    //to fix the bug when we change a weapon, we should not stay in the zoom mode
    private void OnDisable()
    {
        ZoomOut();
    }
    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }
}
