using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene(sceneName:"save1");
        Debug.Log('b');
    }
    private void Update()
    {
        Mouse();
    }
    public void Mouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneName: "save1");
        }
    }
}
