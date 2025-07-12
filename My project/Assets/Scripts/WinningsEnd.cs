using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningsEnd : MonoBehaviour
{
    private int sec;
    private float time;

    public void Start()
    {
        sec = 0;
        time = 0f;
    }
    public void Update()
    {
        time += Time.deltaTime;
        if (time >= 5f)
        {
            sec++;
            time = 0f;
            SceneManager.LoadScene("Menu");
        }
    }
}
