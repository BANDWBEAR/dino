using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    [SerializeField] private Collider2D CrouchCollider;
    [SerializeField] private Collider2D StandCollider;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public int health = 10;
    public int maxHealth = 10;
    public Animator animator;
    public Joystick joystick;
    public HealthBar healthBar;
    public CameraShake cameraShake;

    //private bool jumpHold = false;
    //private bool crouchHold = false;
    private bool jump = false;
    private bool crouch = false;



    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
    }


    public void takeDamage(int damage) {
        health = health - damage;
        healthBar.SetHealth(health);
        StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        Handheld.Vibrate();
        if (health <= 0) {
            Time.timeScale = 0.05f;
        }
    }

    private void death() {

    }

    protected override void ComputeVelocity()
    {
        
        float verticalMove = joystick.Vertical;
        Vector2 move = Vector2.zero;
        move.x = joystick.Horizontal;


        if (verticalMove > 0.2f)
        {
            jump = true;
        }
        else if (verticalMove < -0.2f)
        {
            crouch = true;
        }
        else if (verticalMove < 0.2f && verticalMove > -0.2f)
        {
            jump = false;
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .6f;
                
            }
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        WhatToDo();

        //if (Input.GetButtonDown("Jump"))
        //{
        //    jumpHold = true;
        //    if (grounded)
        //    {
        //        velocity.y = jumpTakeOffSpeed;

        //    }
        //}
        //else if (Input.GetButtonUp("Jump"))
        //{
        //    jumpHold = false;
        //    if (velocity.y > 0)
        //    {
        //        velocity.y = velocity.y * .6f;
        //    }
        //}
        //else if (jumpHold && grounded)
        //{
        //    crouchHold = false;
        //    velocity.y = jumpTakeOffSpeed;
        //}



        //if (Input.GetButtonDown("Crouch"))
        //{
        //    crouchHold = true;
        //    if (grounded)
        //    {
        //        CrouchCollider.enabled = true;
        //        StandCollider.enabled = false;
        //        animator.SetBool("Crouch", crouchHold);

        //    }
        //}
        //else if (Input.GetButtonUp("Crouch"))
        //{
        //    crouchHold = false;
        //    CrouchCollider.enabled = false;
        //    StandCollider.enabled = true;
        //    animator.SetBool("Crouch", crouchHold);
        //}
        //else if (crouchHold && grounded)
        //{
        //    CrouchCollider.enabled = true;
        //    StandCollider.enabled = false;
        //    animator.SetBool("Crouch", crouchHold);

        //}

        targetVelocity = move * maxSpeed;
    }

    void WhatToDo()
    {
        if (grounded)
        {
            if (jump)
            {
                crouch = false;
                velocity.y = jumpTakeOffSpeed;
                CrouchCollider.enabled = false;
                StandCollider.enabled = true;
                animator.SetBool("Crouch", crouch);
            }
            else if (crouch)
            {
                jump = false;
                CrouchCollider.enabled = true;
                StandCollider.enabled = false;
                animator.SetBool("Crouch", crouch);
            }
            else if (!crouch && !jump)
            {
                crouch = false;
                jump = false;
                CrouchCollider.enabled = false;
                StandCollider.enabled = true;
                animator.SetBool("Crouch", crouch);
            }
        }

    }



}
