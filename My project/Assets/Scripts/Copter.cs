using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _gravity = 2.0f;
    
    public AudioClip clickSound;
    public AudioClip breakSound;
    AudioSource audio;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio.PlayOneShot(clickSound);
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
                    audio.PlayOneShot(clickSound);
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
            audio.PlayOneShot(breakSound);
            _rb.gravityScale = _gravity;
            SceneManager.LoadScene("Lose");
        }
        else if(other.gameObject.tag == "Winner")
        {
            _rb.gravityScale = _gravity;
            SceneManager.LoadScene("Win");
        }

        transform.GetComponent<Rigidbody2D>().mass = 0;
    }
}
