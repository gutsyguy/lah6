using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private float speed = 1.0f;
    private float flightForce = 10.0f;
    private bool flightPhase = true;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Fly();
        rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space) && flightPhase == true)
        {
            rb.AddForce(Vector2.up * flightForce, ForceMode2D.Impulse);
        }


    }
}
