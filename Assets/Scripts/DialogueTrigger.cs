using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    private bool AllowInteract;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void Update()
    {
        if (AllowInteract == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            AllowInteract = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            AllowInteract = false;
        }

    }

}
