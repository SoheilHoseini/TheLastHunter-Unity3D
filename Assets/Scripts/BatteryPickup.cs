using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float angleAmount = 80f;
    [SerializeField] float intensityAmount = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(intensityAmount);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(angleAmount);
            Destroy(gameObject);
        }
    }
}
