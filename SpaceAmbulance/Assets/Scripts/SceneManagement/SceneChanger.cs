using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Scene changer with fade in/fade out
/// </summary>
public class SceneChanger : MonoBehaviour
{
    public GameObject _fade;
   
    public void Menu() => _fade.GetComponent<SceneTransition>().ChangeScene("Menu");

    public void FirstLevel() => _fade.GetComponent<SceneTransition>().ChangeScene("FirstLevel");

    public void SecondLevel() => _fade.GetComponent<SceneTransition>().ChangeScene("SecondLevel");

    public void Titry() => _fade.GetComponent<SceneTransition>().ChangeScene("Titry");

    public void Authors() => _fade.GetComponent<SceneTransition>().ChangeScene("Authors");

    public void VideoEnd() => _fade.GetComponent<SceneTransition>().ChangeScene("VideoEnd");

    public void VideoStart() => _fade.GetComponent<SceneTransition>().ChangeScene("VideoStart");
}
