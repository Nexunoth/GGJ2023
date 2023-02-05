using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Rigidbody2D RigidBody2D;
    public Movementscript MovementScript;
    float DistanceBeforeLanding = 1.5f;
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        MovementScript = GetComponent<Movementscript>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if (MovementScript.isGrounded == false)
         {
            Animator.Play("Player_Ani_JumpStart", 0, 0);
            Animator.Play("Player_Ani_JumpLoop", 0, 0);


            RaycastHit2D hit;
            // We check if the ray intersect any objects excluding the player layer
            // !!!!!You need to be careful about the layer you want to use!!!!!
            // We send a ray from the player's position in his velocity direction
            hit = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(RigidBody2D.velocity.x, RigidBody2D.velocity.y)), Mathf.Infinity, 1, -2.9f, -2.9f);
             
                 if (hit.distance >= DistanceBeforeLanding && transform.TransformDirection(new Vector2(RigidBody2D.velocity.x,RigidBody2D.velocity.y)).y <= 0)
                 {
                    Animator.Play("Player_Ani_JumplLoop", 0, 0);
                 }
                 else
                 {
                    Animator.Play("Player_Ani_JumpEnd", 0, 0);

            }
             

         }
    }
}
