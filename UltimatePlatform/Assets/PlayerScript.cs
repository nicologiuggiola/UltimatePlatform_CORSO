using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    
    public float speed;
    public float jumpSpeed;

    private Animator animator;
    private Rigidbody2D rb2d;
    private new SpriteRenderer renderer;
    private Vector2 movement;
    private bool activateJump;
    private bool isJumping;


    // Start is called before the first frame update
    void Start()
    {
        speed = 400;
        jumpSpeed = 20000;
        movement = Vector2.zero;
        rb2d = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        activateJump = false;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");



        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            activateJump = true;
        }

        GestisciAnimazioni();
    }

    private void FixedUpdate()
    {
        if (!isJumping)
        {
            Vector2 forza = movement * speed * Time.fixedDeltaTime;
            rb2d.AddForce(forza);
        }
        
        if (activateJump)
        {
            Vector2 forzaDiSalto = Vector2.up * jumpSpeed * Time.fixedDeltaTime;
            rb2d.AddForce(forzaDiSalto);
            activateJump = false;
            isJumping = true;
            animator.SetTrigger("jump");
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    private void GestisciAnimazioni()
    {
        if (movement.x > 0)
        {
            renderer.flipX = false;
        }
        else if(movement.x < 0)
        {
            renderer.flipX = true;
        }

        if(movement.x == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
    }
}
