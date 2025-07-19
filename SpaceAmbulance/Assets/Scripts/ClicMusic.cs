using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Just sound of "tap" on clicks
/// </summary>
public class ClicMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    void Update()
    {
        if (Input.touchCount > 0)
            if (Input.GetTouch(0).phase == TouchPhase.Began)
                audioSource.PlayOneShot(clip, 0.2f);
    }
}
