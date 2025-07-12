using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBarManager : MonoBehaviour
{
    private float maxTime = 60.0f;
    private float time = 0.0f;

    [SerializeField] private Slider progressBar;
    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= maxTime)
        {
            SceneManager.LoadScene("Win");
        }

        progressBar.value = time / maxTime;
    }
}
