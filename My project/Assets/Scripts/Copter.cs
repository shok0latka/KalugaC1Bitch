using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _gravity = 2.0f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(0, 0);
            _rb.gravityScale = -_gravity;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _rb.gravityScale = _gravity;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _rb.velocity = new Vector2(0, 0);
                    _rb.gravityScale = -_gravity;
                    break;
                
                case TouchPhase.Ended:
                    _rb.gravityScale = _gravity;
                    break;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Killer")
        {
            _rb.gravityScale = _gravity;
            SceneManager.LoadScene("Lose");
        }
    }
}
/*
 *         
 */