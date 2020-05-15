using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    private bool options = false;
    public static bool NotepadOpen = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsMenu;
    public GameObject MainPauseMenu;
    public GameObject NotepadMenu;
    public Text FOVValue;
    public Text SenValue;
    private float AngularSpeedHold;

    /// <summary>
    /// Called when the escape button is pushed. Pauses, resumes, or moves
    /// back in the pause menu as needed
    /// </summary>
    /// <param name="context"></param>
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

    /// <summary>
    /// Opens and closes the notepad when the button is pressed.
    /// </summary>
    /// <param name="context"></param>
    public void OnNotepad(InputAction.CallbackContext context)
    {
        if (Paused)
        {
            return;
        }

        if (!NotepadOpen)
        {
            OpenNotepad();
        }
        else
        {
            CloseNotepad();
        }
    }

    /// <summary>
    /// Operns notepad
    /// </summary>
    public void OpenNotepad()
    {
        NotepadMenu.SetActive(true);
        AngularSpeedHold = FirstPersonController.AngularSpeed;
        FirstPersonController.AngularSpeed = 0;
        NotepadOpen = true;

    }

    /// <summary>
    /// Closes notepad
    /// </summary>
    public void CloseNotepad()
    {
        NotepadMenu.SetActive(false);
        FirstPersonController.AngularSpeed = AngularSpeedHold;
        NotepadOpen = false;
    }

    /// <summary>
    /// Opens pause menu
    /// </summary>
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        Paused = true;
    }

    //Closes pause menu
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }

    /// <summary>
    /// Exits to the main menu
    /// </summary>
    public void MenuExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Opens and closes the options menu
    /// </summary>
    public void Options()
    {
        MainPauseMenu.SetActive(options);
        OptionsMenu.SetActive(!options);
        options = !options;
    }

    /// <summary>
    /// Adjusts the FOV from the options menu
    /// </summary>
    /// <param name="fov">The new FOV value</param>
    public void FOV(float fov)
    {
        Camera.main.fieldOfView = fov;
        int fovInt = (int)Mathf.Round(fov);
        string valueText = fovInt.ToString();
        FOVValue.text = valueText;
    }

    /// <summary>
    /// Adjusts the mouse sensitivity
    /// </summary>
    /// <param name="sen">The new sensetivity level</param>
    public void Senseitivity(float sen)
    {
        FirstPersonController.AngularSpeed = sen;
        sen = (float)(sen / 60.0f);
        string valueText = sen.ToString("n2");
        SenValue.text = valueText;
    }
}
