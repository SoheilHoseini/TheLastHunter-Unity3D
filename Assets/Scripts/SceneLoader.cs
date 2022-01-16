using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //reload the game when we hit "Play Again" button
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    //reload the game when we hit "Quit" button
    public void QuitGame()
    {
        Application.Quit();
    }
}
