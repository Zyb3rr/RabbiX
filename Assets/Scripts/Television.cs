using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour
{
    private bool AllowInteract;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowInteract == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (anim.GetBool("IsON") == true)
                {
                    anim.SetBool("IsON", false);
                }
                else if (anim.GetBool("IsON") == false)
                {
                    anim.SetBool("IsON", true);
                }
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
