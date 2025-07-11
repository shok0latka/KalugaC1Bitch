using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private int sec;
    private float time;



    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<TMP_Text>().text = "BRUH";
        sec = 0;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1f)
        {
            sec++;
            time = 0f;
            transform.GetComponent<TMP_Text>().text = $"{sec}";
        }
    }
}
