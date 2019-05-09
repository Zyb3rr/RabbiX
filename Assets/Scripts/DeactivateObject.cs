using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    public GameObject ObjectToDeactivate;
    private bool AllowInteract;

    // Update is called once per frame
    void Update()
    {
        if (AllowInteract == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ObjectToDeactivate.SetActive(false);
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
