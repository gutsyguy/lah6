using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource jumperTheme;
    // Start is called before the first frame update
    void Start()
    {
        jumperTheme = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "player")
        {
            jumperTheme.Play();
        }
    }
}
