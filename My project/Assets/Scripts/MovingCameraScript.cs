using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour

{
    [SerializeField] private GameObject Player;
    [SerializeField] private float speed = 0f;
    [SerializeField] private GameObject _progressBar;
    public float vilosity = 0f;
    private bool _isFirstTime; 

// Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f,0.14f,-10f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed += vilosity;
        transform.Translate(speed, 0f, 0f);
        Player.transform.Translate(speed, 0f, 0f);
    }
    
    void Update()
    {
        
            

        if ((Input.touchCount > 0) || (Input.GetKey(KeyCode.Space))) //When Player Touch - start
        {
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Debug.Log("Space was pressed");
            _progressBar.SetActive(true);
            speed = 0.04f;
            vilosity = 0.000015f;
        }
    }

    private void OnDestroy() //Keep all data to start position
    {
        
        speed = 0f;
        _isFirstTime = true;
    }
}
