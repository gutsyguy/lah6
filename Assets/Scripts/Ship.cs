using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private float speed = 3.0f;
    private float flightForce = 3.0f;
    private Rigidbody2D rb;
    private bool isGrounded;

    private float flightSpeed = 3.0f;
    private bool isFlying = false;
    private bool isWalking = true;
    private int FlyDirection = -1;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (isWalking == true){
            Walk();
        }
        if (isFlying == true){
            Fly();
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            Debug.Log("JUMPABLE");
            isGrounded = true;
        }
        else if (col.gameObject.tag == "obstacle")
        {}
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("WORK");
        if (col.gameObject.tag == "FlyPortal")
        {
            isFlying = true;
            isWalking = false;
        }
        else if (col.gameObject.tag == "WalkPortal")
        {
            isFlying = true;
            isWalking = false;
        }
        Debug.Log(isFlying);
    }
        
        
    
    private void Walk()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = new Vector2(speed, flightForce);
            rb.AddForce(Vector2.up * flightForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FlyDirection == -1)
            {
                FlyDirection = 1;
            }
            else {
                FlyDirection = -1;
            }
        }

        rb.velocity = new Vector2(rb.velocity.x, flightSpeed * FlyDirection);

    }

}
