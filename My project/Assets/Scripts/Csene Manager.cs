using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CseneManager : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene("Level");
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void Lose()
    {
        SceneManager.LoadScene("Lose");
    }
    
    public void Waiting()
    {
        SceneManager.LoadScene("Waiting");
    }
}
