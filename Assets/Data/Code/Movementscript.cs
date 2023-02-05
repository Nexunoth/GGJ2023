using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementscript : MonoBehaviour
{
    public float JumpForce;
    public float MoveSpeed;
    public Rigidbody2D RigidBody2D;
    public float Root ;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Rooting", 2f, 2f);
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Root < 0)
        {
            Root = 0;
        }
        
        float Speed = Input.GetAxis("Horizontal") * MoveSpeed * Root * 2;
        if (Input.GetButtonDown("Jump") == true && isGrounded == true)
        {
            float Jump = (JumpForce * Root) + (JumpForce * 0.2f);
            RigidBody2D.velocity = new Vector3(Speed, Jump, 0);
            Root = 1; 
        }
        else
        {
            Vector2 forward = new Vector2(Speed, 0);
            RigidBody2D.AddForce(forward) ;
        }
        if (Input.GetAxis("Vertical") == -1)
        {
            Root -= 0.001f;
        }




    }
    void Rooting() 
    {
        if (isGrounded == true)
        {
            Root -= 0.1f;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }



}
