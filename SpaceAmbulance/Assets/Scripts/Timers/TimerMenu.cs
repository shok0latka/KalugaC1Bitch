using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Timer to return in menu after 1.5 minutes without activity
/// </summary>
public class TimerMenu : MonoBehaviour
{
    public GameObject _fade;

    public float _time = 0.0f;

    public void Menu() => _fade.GetComponent<SceneTransition>().ChangeScene("Menu");

    void Update()
    {
        _time += Time.deltaTime;
        if (Input.anyKeyDown)
        {
            _time = 0.0f;
        }
        if(_time > 90.0f)
        {
            Menu();
        }
    }
}
