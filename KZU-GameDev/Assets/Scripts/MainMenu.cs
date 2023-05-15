using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public static bool bubblesSpawn = false;
    public static bool fynnSpawn = false;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SpawnBubbles()
    {
        bubblesSpawn = true;
        fynnSpawn = false;
    }

    public void SpawnFynn()
    {
        fynnSpawn = true;
        bubblesSpawn = false;
    }
    
}
