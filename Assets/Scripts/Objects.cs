using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float WaitTime;

    // Start is called before the first frame update
    void Start()
    {
       effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            WaitTime = 0.1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (WaitTime <= 0)
            {
                effector.rotationalOffset = 180;
                WaitTime = 0.1f;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }
    }
}
