using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningsEnd : MonoBehaviour
{
    private int sec;
    private float time;
    private bool YaNePridumal;
    [SerializeField] public GameObject[] _buttons;
    

    public void Start()
    {
        YaNePridumal = true;
        time = 0f;
    }
    public void Update()
    {
        time += Time.deltaTime;
        if (time >= 14f && YaNePridumal)
        {
            
            YaNePridumal = false;
            foreach (var light  in _buttons)
                light.GameObject().SetActive(!light.GameObject().activeSelf);
            
        }
        if (time >= 18f)
        {
            time = 0f;
            SceneManager.LoadScene("New Menu");
        }

        
    }
}
