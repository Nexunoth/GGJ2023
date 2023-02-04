using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    public float JumpForce;
    public float MoveSpeed;
    public Rigidbody2D RigidBody2D;
    float Root=1;
    private float RootCounter; 
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
        }else{
            RootCounter = 0;
        }
        if (RootCounter == 15)
        {
            Root -= 0.1f;
            RootCounter = 0;
        }
        float Speed = Input.GetAxis("Horizontal") * MoveSpeed * Root;
        if (Input.GetButtonDown("Jump") == true && isGrounded == true)
        {
            float Jump = JumpForce *Root;
            RigidBody2D.velocity = new Vector3(Speed, Jump, 0);
            Root = 1;
            
        }else{
            Vector2 forward = new Vector2(Speed, 0);
            RigidBody2D.AddForce(forward);
        }
        if (Input.GetAxis("Vertical") == -1 && isGrounded == true)
        {
            Root -= 0.001f;  
        }

            



    }
    void OnCollisionEnter2D(Collision2D col)
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
