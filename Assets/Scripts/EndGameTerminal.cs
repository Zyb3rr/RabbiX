using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTerminal : MonoBehaviour
{
    private bool AllowInteract;

    public GameObject ObjActivate;
    public GameObject ObjDeActivate;

    // Update is called once per frame
    void Update()
    {
        if (AllowInteract == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Activate());
                StartCoroutine(DeActivate());

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


   IEnumerator Activate()
    {


        yield return new WaitForSeconds(10f);
        ObjActivate.SetActive(true);
    }

    IEnumerator DeActivate()
    {


        yield return new WaitForSeconds(11f);
        ObjDeActivate.SetActive(false);
    }

}
