﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{

    private bool AllowInteract;
    private LevelManager _LevelManager;
    public GameObject levelManager;



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
                _LevelManager = levelManager.GetComponent<LevelManager>();
                if (_LevelManager != null)
                {
                    _LevelManager.FadeToNextLevel();
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
