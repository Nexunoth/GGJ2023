using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementscript : MonoBehaviour
{
    public float JumpForce;
    public float MoveSpeed;
    public Rigidbody2D RigidBody2D;
    float Root = 1;
    float RootCounter = 0;
    bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            RootCounter++;
        }
        if (RootCounter == 15)
        {
            Root -= 0.1f;
            RootCounter = 0;
        }
        float Speed = Input.GetAxis("Horizontal") * MoveSpeed;
        if (Input.GetButtonDown("Jump") == true && isGrounded == true)
        {
            float Jump = JumpForce * Root;
            RigidBody2D.velocity = new Vector3(Speed, Jump, 0);
            Root = 1; 
        }
        else
        {
            RigidBody2D.velocity = new Vector3(Speed, 0, 0);
        }
        if (Input.GetAxis("Vertical") == -1)
        {
            Root -= 0.01f;
        }




    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }



}
