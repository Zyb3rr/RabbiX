using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectActive : MonoBehaviour
{

    public GameObject ObjectToSetActive;
    private bool AllowInteract;

    // Update is called once per frame
    void Update()
    {
        if (AllowInteract == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ObjectToSetActive.SetActive(true);
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
