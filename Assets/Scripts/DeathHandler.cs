using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;//nothing on the screen at the beggining
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;// show death menu when player dies

        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false; // Does not allow the player to switch weapon after death
        Cursor.lockState = CursorLockMode.None;// allow the player to use mouse cursor
        Cursor.visible = true;// make the cursor visible
    }
}
