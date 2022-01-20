using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;// How much the flash light is fading over time
    [SerializeField] float angleDecay = 0.5f; // The amount of range decreasing
    [SerializeField] float minimumAngle = 40f; // Flash light angle can not go below this

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    //when we pick battery the angle shoud increase
    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    //when we pick battery the angle shoud increase
    public void AddLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }


    private void DecreaseLightAngle()
    {
        //flash light angle should not go below minimumAngle
        if (myLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    
}
