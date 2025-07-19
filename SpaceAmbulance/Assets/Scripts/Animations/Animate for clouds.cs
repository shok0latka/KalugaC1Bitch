using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private int z = 8;
    private int sec = 0;
    private float time = 0f;
    
    void Update()
    {
        
        time += Time.deltaTime;
        if (time >= 1f)
        {
            sec++;
            time = 0f;
            transform.rotation = Quaternion.Euler(0, 0, z);
            z *= -1;
        }
        
    }
}
