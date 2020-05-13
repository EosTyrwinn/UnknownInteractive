using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    private bool options = false;
    private bool NotepadOpen = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsMenu;
    public GameObject MainPauseMenu;
    public GameObject NotepadMenu;
    public Text FOVValue;
    public Text SenValue;
    private float AngularSpeedHold;

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

    public void OpenNotepad()
    {
        NotepadMenu.SetActive(true);
        AngularSpeedHold = FirstPersonController.AngularSpeed;
        FirstPersonController.AngularSpeed = 0;
        NotepadOpen = true;
    }

    public void CloseNotepad()
    {
        NotepadMenu.SetActive(false);
        FirstPersonController.AngularSpeed = AngularSpeedHold;
        NotepadOpen = false;
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
        OptionsMenu.SetActive(!options);
        options = !options;
    }

    public void FOV(float fov)
    {
        Camera.main.fieldOfView = fov;
        int fovInt = (int)Mathf.Round(fov);
        string valueText = fovInt.ToString();
        FOVValue.text = valueText;
    }

    public void Senseitivity(float sen)
    {
        FirstPersonController.AngularSpeed = sen;
        sen = (float)(sen / 60.0f);
        string valueText = sen.ToString("n2");
        SenValue.text = valueText;
    }
}
