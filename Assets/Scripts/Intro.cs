using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject click;
    public Transform transform;
    private void Awake()
    {
        click = GetComponent<GameObject>();
        transform = GetComponent<Transform>();
        

    }
    // Update is called once per frame



    private void Onclick()
    {

    }
}
