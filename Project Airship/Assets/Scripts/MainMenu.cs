using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Called to start the game
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }

    /// <summary>
    /// Called to exit the game
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
