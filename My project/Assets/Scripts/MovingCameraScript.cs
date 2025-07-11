using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour

{
    [SerializeField] private GameObject Player;
    [SerializeField] private float speed = 0.04f;

// Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-0f,0.14f,-10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0f, 0f);
        Player.transform.Translate(speed, 0f, 0f);
    }
}
