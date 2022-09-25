using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    private float speed = 6.25f;
    private float flightForce = 5.8f;
    private Rigidbody2D rb;

    private float flightSpeed = 3.0f;
    private bool isFlying = false;
    private bool isWalking = true;
    private bool isUpside = false;
    private int FlyDirection = -1;

    private int jump_count = 0;
    private int max_jump_count = 100;
    private bool win;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame

    private void Update()
    {
        if (isWalking == true)
        {
            rb.gravityScale = 3;
            Walk();
        }
        if (isFlying == true)
        {
            rb.gravityScale = 0;
            Fly();
        }
        if (isUpside == true)
        {
            rb.gravityScale = -3;
            Upside();
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);

        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        float origin_pos = rb.position.x;
        yield return new WaitForSeconds(0.05f);
        float new_pos = rb.position.x;
        if (origin_pos - new_pos == 0)
        {
            //PLACEHOLDER
            SceneManager.LoadScene(0);
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Ground")
        {
            jump_count = 0;
        }
        else if (col.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene(0);
        }
        else if (col.gameObject.tag == "enemy")
        {
            if (rb.velocity.x <= 0)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "FlyPortal")
        {
            isFlying = true;
            isWalking = false;
            isUpside = false;
        }
        else if (col.gameObject.tag == "WalkPortal")
        {
            isFlying = false;
            isWalking = true;
            isUpside = false;
        }
        else if (col.gameObject.tag == "UpsidePortal")
        {
            isFlying = false;
            isWalking = false;
            isUpside = true;
        }
        else if (col.gameObject.tag == "End")
        {
            SceneManager.LoadScene(sceneName: "s");

        }
    }

    private void Upside()
    {
        Debug.Log(rb.velocity);
        FlyDirection = 0;
        if (Input.GetKeyDown(KeyCode.Space) && max_jump_count > jump_count)
        {
            rb.velocity = new Vector2(speed, flightForce);
            rb.AddForce(Vector2.down * flightForce * 2, ForceMode2D.Impulse);
            jump_count++;
        }
    }

    private void Walk()
    {
        FlyDirection = 0;
        if (Input.GetKeyDown(KeyCode.Space) && max_jump_count > jump_count)
        {
            rb.velocity = new Vector2(speed, flightForce);
            rb.AddForce(Vector2.up * flightForce, ForceMode2D.Impulse);
            jump_count++;
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
            else
            {
                FlyDirection = -1;
            }
        }

        rb.velocity = new Vector2(rb.velocity.x, flightSpeed * FlyDirection);

    }

}
