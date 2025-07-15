using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Script : MonoBehaviour

{
    [SerializeField] private float _cSpeedX = 0;
    [SerializeField] private float _cSpeedY = 0;
    [SerializeField] private Vector3 _scaleCSpeed;
    
    [SerializeField] private GameObject Player;
    [SerializeField] private float speed = 0f;
    [SerializeField] private GameObject _progressBar;
    [SerializeField] private GameObject _Soyuz;
    public float vilosity = 0f;
    private bool _isFirstTime;
    

    private bool _isStarted = false;

    private SpriteRenderer _soyuzSprite;
// Start is called before the first frame update
    void Start()
    {
        
        transform.position = new Vector3(0f,0.14f,-10f);
        _Soyuz.transform.localScale = new Vector3(30,36.95923f, 54.16821f);
        _scaleCSpeed = new Vector3(30, 36.95923f, 54.16821f);
        _isFirstTime = true;
        _soyuzSprite = _Soyuz.GetComponent<SpriteRenderer>();


    }

    public void SetSpeed(float _speed) => speed = _speed;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        speed += vilosity;
        transform.Translate(speed, 0f, 0f);
        Player.transform.Translate(speed, 0f, 0f);
        _Soyuz.transform.Translate(_cSpeedX,_cSpeedY,0f);
        


    }
    
    void Update()
    {
        
        if (((Input.touchCount > 0) || (Input.GetKey(KeyCode.Space))) && _isFirstTime) //When Player Touch - start
        {
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
            _progressBar.SetActive(true);
            speed = 0.04f;
            vilosity = 0.000015f;
            _cSpeedY = -0.00001f * 3f;
            _cSpeedX = -0.008f * 0.8f;
            _scaleCSpeed = new Vector3(200, 199.9957f, 208.5682f);
            _Soyuz.transform.DOScale(_scaleCSpeed, 60);
            _soyuzSprite.DOFade(1f, 45f);
            

            
            _isFirstTime = false;
        }
        
    }

    private void OnDestroy() //Keep all data to start position
    {
        
        speed = 0f;
        _isFirstTime = true;
    }

    
}
