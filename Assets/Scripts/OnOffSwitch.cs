using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffSwitch : MonoBehaviour
{

    [SerializeField]
    GameObject SwitchON;

    [SerializeField]
    GameObject SwitchOFF;

    [SerializeField]
    GameObject Light;

    [SerializeField]
    GameObject LightOn;

    [SerializeField]
    GameObject LightOff;

    [SerializeField]
    GameObject LightSource;

    public bool isON = false;
    private bool AllowInteract;


    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOFF.GetComponent<SpriteRenderer>().sprite;
        isON = false;
    }

    void Update()
    {
if(AllowInteract == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                if (isON == true)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOFF.GetComponent<SpriteRenderer>().sprite;
                    Light.GetComponent<SpriteRenderer>().sprite = LightOff.GetComponent<SpriteRenderer>().sprite;
                    LightSource.GetComponent<Light>().enabled = false;
                    isON = false;
                }
                else if (isON == false)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = SwitchON.GetComponent<SpriteRenderer>().sprite;
                    Light.GetComponent<SpriteRenderer>().sprite = LightOn.GetComponent<SpriteRenderer>().sprite;
                    LightSource.GetComponent<Light>().enabled = true;
                    isON = true;
                }

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        AllowInteract = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        AllowInteract = false;
    }

}
