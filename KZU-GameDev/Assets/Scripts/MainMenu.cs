using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject Bubbles;
    public GameObject Fynn;
    
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
        Instantiate(Bubbles); //muss man noch zugreifen können
        SceneManager.MoveGameObjectToScene(Bubbles, SceneManager.GetSceneByName("KZU-Game Dev"));
    }

    public void SpawnFynn()
    {
        Instantiate(Fynn);
        SceneManager.MoveGameObjectToScene(Fynn, SceneManager.GetSceneByName("KZU-Game Dev"));
    }
    
}
