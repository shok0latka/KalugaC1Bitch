using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMoving : MonoBehaviour
{
    [SerializeField] public float Speed = 0.1f;
    // Start is called before the first frame update
    

   
    void Update() => transform.Translate(0f,Speed,0f);
    
        
    
}
