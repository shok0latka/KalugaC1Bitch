using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Threading;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor.VersionControl;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public GameObject Camera;
    private Rigidbody2D _rb;
    private float _gravity = 2.0f;
    
    public AudioClip clickSound;
    public AudioClip breakSound;
    AudioSource audio;
    

    private float _time = 0;
    private bool _endTimer = false; 
    void Start()
    {
        _endTimer = false;
        _rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Timer
        if (_endTimer)
            _time += Time.deltaTime;
        
        if (_time >= 4f)
            SceneManager.LoadScene("Win");
        
        
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
        if (other.gameObject.tag == "Killer" && _endTimer == false)
        {
            audio.PlayOneShot(breakSound);
            _rb.gravityScale = _gravity;
            SceneManager.LoadScene("Lose");
        }
        else if(other.gameObject.tag == "Winner")
        {
            transform.DOMove(new Vector3(184, -3, 0) , 5);
            
            Camera.GetComponent<Script>().SetSpeed(0);
            _rb.gravityScale = _gravity;
            _endTimer = true;

        }

        transform.GetComponent<Rigidbody2D>().mass = 0;
    }
}
