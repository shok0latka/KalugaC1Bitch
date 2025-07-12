using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvents : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Button _bigButton;
    private float _targetTime;
    private int _count;
    IEnumerator start() //event about multiButtons
    {
        foreach (Button button in _buttons)
            button.gameObject.SetActive(false);

        foreach (Button button in _buttons)
        {
            bool isFailed = true;

            void HandleClick() => isFailed = false;

            button.gameObject.SetActive(true);
            button.transform.localScale = Vector3.zero;
            button.transform.DOScale(Vector3.one, 0.2f);


            button.onClick.AddListener(HandleClick);

            _targetTime = Time.time + 3;

            while (Time.time < _targetTime && isFailed)
                yield return null;

            button.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => button.gameObject.SetActive(false));

            if (isFailed)
            {
                //TODO FAILED

                yield break;
            }
        }

        //TODO SUCCESS
    }

    IEnumerator Start()
    {
        _bigButton.GameObject().SetActive(true);
        _targetTime = Time.time + 5f;
        _count = 0;
        _bigButton.onClick.AddListener(ButtonCounter);

        while (_count != 5)
            yield return null;

        _bigButton.GameObject().SetActive(false);




        yield break;
    } //event about 1 Button


    void ButtonCounter()
    {
        _count++;
        //Extra Fuctional
    }

}
