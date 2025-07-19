using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Changing scene wuth video after const time;
/// </summary>
public class SceneEndingVideoStart : MonoBehaviour
{
    public GameObject _fade;
    public float _time = 0.0f;
    public float _maxTime = 12.0f;
    public bool _isPlaying = false;
    void FirstLevel() => _fade.GetComponent<SceneTransition>().ChangeScene("FirstLevel");
    void Start()
    {
        _isPlaying = true;
    }

    void Update()
    {
        if (_isPlaying)
        {
            _time += Time.deltaTime;
            if (_time > _maxTime)
            {
                FirstLevel();
            }
        }
    }
}
