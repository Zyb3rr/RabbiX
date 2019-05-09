using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement Variables
    public float Speed;
    public float JumpForce;
    private float MoveInput;
    private Animator anim;
    public SpriteRenderer sr;
    public GameObject interactiveobjectbox;
    private AudioSource audis;
    public GameObject SpawnManager;

    private bool dying;

    private Rigidbody2D rb;

    //Ground Stuff
    private bool IsGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;

    //Jumping
    private int ExtraJumps;
    public int ExtraJumpsValue;

    //respawn 
    public Vector3 respawnPoint;

    //spawn

    public Vector3 spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        ExtraJumps = ExtraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        audis = GetComponent<AudioSource>();
        transform.position = spawnPoint;
        respawnPoint = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);

        MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInput * Speed, rb.velocity.y);
    }


    private void Movement()
    {
        if (IsGrounded == true)
        {
            ExtraJumps = ExtraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && ExtraJumps > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            anim.SetTrigger("Jump");
            ExtraJumps--;
            audis.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && ExtraJumps == 0 && IsGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;
            audis.Play();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            sr.flipX = true;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            sr.flipX = false;
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Interactable")
        {
            interactiveobjectbox.SetActive(true);
        }
        else if(col.tag == "Projectile")
        {
            if(dying == false)
            {
                dying = true;
                audis.Play();
                StartCoroutine(Die());
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Interactable")
        {
            interactiveobjectbox.SetActive(false);
        }
    }

    private IEnumerator Die()
    {
        SpawnManager.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        transform.position = respawnPoint;
    }

}
