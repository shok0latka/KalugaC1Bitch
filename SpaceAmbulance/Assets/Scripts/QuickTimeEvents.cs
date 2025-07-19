using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class QuickTimeEvents : MonoBehaviour
{
    // text under quests
    [SerializeField] private Text _textAdd1;
    [SerializeField] private Text _textAdd2;

    
    [SerializeField] private Button _buttonNext; // button "next"
    [SerializeField] private Button[] _buttons; // buttons for first QTE
    [SerializeField] private Button _bigButton; // button for second QTE

    // checks in quests
    [SerializeField] private GameObject _checkOne;
    [SerializeField] private GameObject _checkTwo;


    [SerializeField] private GameObject _pulse; // Pulse Image parent
    [SerializeField] private GameObject _pulsePos; // Start Pulse position
    [SerializeField] private GameObject _naPalec; // Image when pulse on finger
    [SerializeField] private GameObject _naPalecGhost; // Image on finger when pulse not on finger

    [SerializeField] private GameObject _tahometrKeeper; // Taho keeper (Check script Tahometr Keeper)
    [SerializeField] private GameObject _taho; // Taho Image Parent
    [SerializeField] private GameObject _tahoPos; //  Start Taho position
    [SerializeField] private GameObject _allTaho; // Parent for all images we see, when Taho on arm
    [SerializeField] private GameObject _tahoGhost; // Image on arm when Taho not on arm
    [SerializeField] private GameObject _tahoImage; // Taho Image

    // audio player
    [SerializeField] private AudioSource audioSource; 
    [SerializeField] private AudioClip clip;

    private int _count = 0; // _count for clicks in second QTE

    // Text setter coroutine (DOTween's DOText looks a big worse then it)
    public IEnumerator SetText(Text _text, string text)
    {
        float timeForOneLetter = 5.0f / text.Length;
        for (int i = 0; i < text.Length; ++i)
        {
            _text.text = _text.text + text[i];
            yield return new WaitForSeconds(timeForOneLetter);
        }
    }

    // First QTE, N buttons, you should touch all of them)
    public IEnumerator MultiButton()
    {
        foreach (Button button in _buttons)
            button.gameObject.SetActive(false);

        foreach (Button button in _buttons)
        {
            bool isFailed = true;

            void HandleClick() => isFailed = false;

            button.gameObject.SetActive(true);

            button.onClick.AddListener(HandleClick);

            while (isFailed)
                yield return null;


            button.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => button.gameObject.SetActive(false));
        }
        audioSource.PlayOneShot(clip);

        _pulse.transform.position = _pulsePos.transform.position;

        _naPalec.SetActive(false);
        _naPalecGhost.SetActive(false);

        _checkOne.SetActive(true);

        _tahoGhost.SetActive(true);

        StartCoroutine(SetText(_textAdd1, "Пульс 120 ударов в минуту. Это абсолютная норма после космического полёта. Космонавт пережил сильную перегрузку, его сосудистые рефлексы ослаблены."));
    }

    // Second QTE, 1 buttons, you should touch it N times (3, in this code)
    public IEnumerator OneButton()
    {
        _count = 0;

        _tahoGhost.SetActive(false);
        _taho.SetActive(false);

        _allTaho.SetActive(true);
        _tahoImage.SetActive(true);

        _bigButton.GameObject().SetActive(true);
        _bigButton.onClick.AddListener(ButtonCounter);

        while (_count < 3)
            yield return null;

        audioSource.PlayOneShot(clip);

        _taho.transform.position = _tahoPos.transform.position;
        _tahoImage.SetActive(false);
        _allTaho.SetActive(false);

        _checkTwo.SetActive(true);
 
        _buttonNext.interactable = true;

        StartCoroutine(SetText(_textAdd2, "Давление 90 на 60. Слегка понижено по земным меркам. А вот после пребывания вне земной гравитации это норма."));
    }

    // Extra func for perfect QTE
    void ButtonCounter() => _count++;

}
