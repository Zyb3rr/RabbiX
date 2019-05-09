using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    private bool AllowInteract;
    private bool OneTimeInteract;
    public GameObject SandWich;

    // Start is called before the first frame update
    void Start()
    {
        OneTimeInteract = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowInteract == true)
        {
          if(Input.GetKeyDown(KeyCode.E))
            {
                SandWich.SetActive(true);
                OneTimeInteract = false;
                AllowInteract = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            if(OneTimeInteract == true)
            {
                AllowInteract = true;
            }
        }

    }

}
