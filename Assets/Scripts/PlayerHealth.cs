using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    [SerializeField] Canvas winCanvas;
    [SerializeField] AudioSource winSFX;

    private void Start()
    {
        winCanvas.enabled = false;
    }

    //Take the amount of damage the gun can make and decrease it from enemy health
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Debug.Log("You have been shot baby!");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    //find the cure and win the game
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            Debug.Log("You Found the Cure!");
            Destroy(other.gameObject);
            Win();
        }
    }

    private void Win()
    {
        winCanvas.enabled = true;// show death menu when player dies
        winSFX.Play();
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false; // Does not allow the player to switch weapon after death
        Cursor.lockState = CursorLockMode.None;// allow the player to use mouse cursor
        Cursor.visible = true;// make the cursor visible
    }
}
