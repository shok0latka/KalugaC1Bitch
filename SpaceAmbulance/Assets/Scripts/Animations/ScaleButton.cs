using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ScaleButton : MonoBehaviour
{
    private Vector2 _baseScale;
    public float speed = 1.5f;
    public float amplitude = 1f;
    
    
    void Start()
    {
        _baseScale = transform.localScale;
    }

    
    void Update()
    {
        float delta = amplitude * Math.Abs(Mathf.Sin(Time.time * speed));
        Vector2 newScale = (delta * Vector2.one) + _baseScale;
        transform.localScale = newScale;
    }
}
