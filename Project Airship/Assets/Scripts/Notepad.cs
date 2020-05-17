using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Notepad : MonoBehaviour
{
    public static bool NotepadOpen = false;
    public GameObject NotepadMenu;
    private float AngularSpeedHold;
    private GameObject[,] Notes;
    private int NumNotes;
    public GameObject buttonBase;

    private void Awake()
    {
        Notes = new GameObject[1,4];
        NumNotes = 0;
    }

    /// <summary>
    /// Opens and closes the notepad when the button is pressed.
    /// </summary>
    /// <param name="context"></param>
    public void OnNotepad(InputAction.CallbackContext context)
    {
        if (PauseMenu.Paused)
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
    /// Adds a note about an object to the Notes array
    /// </summary>
    /// <param name="note">The note to add</param>
    public void AddNote(string note)
    {
        //Check if the notes array needs to be resized
        if(NumNotes % 4 == 0 && NumNotes != 0)
        {
            ResizeNotes();
        }

        //Create note
        GameObject noteObj = buttonBase;
        noteObj.GetComponentInChildren<Text>().text = note;

        //Add note to the array
        Notes[(NumNotes / 4), (NumNotes % 4)] = noteObj;

        // TO DO:
        // Add buttons to the notepad pannel
        // Make buttons fit on the notepad
        // Make pages in the notepad
        // Make them usable
        
    }

    /// <summary>
    /// Resizes the Notes array as needed to accomodate more notes
    /// </summary>
    public void ResizeNotes()
    {
        int rows = Notes.GetLength(0);
        int col = Notes.GetLength(1);
        GameObject[,] temp = new GameObject[rows + 1, col];

        for(int r = 0; r < rows; r++)
        {
            for(int c = 0; c < col; c++)
            {
                temp[r, c] = Notes[r, c];
            }
        }

        Notes = temp;
    }
}
