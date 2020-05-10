using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public bool options = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsMenu;
    public GameObject MainPauseMenu;

    public void OnPause(InputAction.CallbackContext context)
    {
        if (Paused)
        {
            if (!options)
            {
                Resume();
            }
            else
            {
                Options();
            }
        }
        else
        {
            Pause();
        }
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        Paused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }

    public void MenuExit()
    {
        Time.timeScale = 1;
        Debug.Log("Going to main menu");
        //Scene manager Stuff
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        MainPauseMenu.SetActive(options);
        options = !options;
        OptionsMenu.SetActive(options);
    }

    public void Button()
    {
    }
}
