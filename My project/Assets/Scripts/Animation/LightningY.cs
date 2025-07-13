using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningX : MonoBehaviour
{
    private float _baseScale;
    public float speed = 1.5f;
    public float amplitude = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        _baseScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Math.Abs(Mathf.Sin(Time.time * speed)) * amplitude;
        var scaleY = transform.localScale;
        scaleY.y = _baseScale + delta;
        transform.localScale = scaleY;
    }
}
