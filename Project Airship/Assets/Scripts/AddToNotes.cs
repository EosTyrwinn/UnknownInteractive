using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToNotes : MonoBehaviour
{
    public string noteName;
    private GameObject player;
    private GameObject ui;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ui = GameObject.FindGameObjectWithTag("UI");
    }

    /// <summary>
    /// Called when the player click on the object
    /// </summary>
    public void OnMouseDown()
    {
        //Check if the player is within 3 meters of the object to add it
        float dist = (transform.position - player.transform.position).magnitude;
        if (dist <= 3)
        {
            ui.GetComponent<Notepad>().AddNote(noteName);
        }
    }
}
