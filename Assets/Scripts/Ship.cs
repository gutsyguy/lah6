using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private float speed = 3.0f;
    private float flightForce = 3.0f;
    private bool flightPhase = true;
    private int jumps;
    private int startJump = 0;
    private Rigidbody2D rb;
    private float bonusGravity = 2.0f;
    private bool reverseZone;
    private bool isGrounded;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Fly();
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "portal")
        {
            Fly();
            reverseZone = false;
        }
        else if(col.gameObject.tag == "reverse portal")
        {
            reverseFly();

        }
        else if(col.gameObject.tag == "obstacle")
        {
            
        }
        else if(col.gameObject.tag == "normalPortal")
        {
            reverseZone = false;
            flightPhase = false;
        }
    }
    private void Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space) && flightPhase == true)
        {
            rb.velocity = new Vector2(speed, flightForce);
            rb.AddForce(Vector2.up * flightForce, ForceMode2D.Impulse);

            do
            {
                Vector3 vel = rb.velocity;
                vel.y -= bonusGravity * Time.deltaTime;
                rb.velocity = vel;
            }
            while (isGrounded == false);
        }
    }
    private void reverseFly()
    {
        while(reverseZone == true)
        {
            rb.gravityScale = -1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && flightPhase == true && reverseZone == true)
        {
            rb.velocity = new Vector2(speed, flightForce);
            rb.AddForce(Vector2.up * flightForce, ForceMode2D.Impulse);

            do
            {
                Vector3 vel = rb.velocity;
                vel.y -= bonusGravity * Time.deltaTime;
                rb.velocity = vel;
            }
            while (isGrounded == false);
        }
    }
        
}
