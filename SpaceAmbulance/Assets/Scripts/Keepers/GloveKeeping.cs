using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class GloveKeeping : MonoBehaviour, IDropHandler
{
    public Button _button;

    public Text _textAdd1;
    public Text _textAdd2;

    public GameObject _glove;
    public GameObject _gloveKeeper;
    public GameObject _gloveImage;

    public bool _isToucheble = false;
    public bool _isKeeping = false;
    public GameObject _sleeve;
    public GameObject _sleeveSpawner;
    public GameObject _check1;
    public GameObject _check2;

    public AudioSource audioSource;
    public AudioClip clip;

    public void OnDrop(PointerEventData eventData) {   
        if(eventData.pointerDrag.tag == "Glove"){
            audioSource.PlayOneShot(clip);
            var otherItemTransform = eventData.pointerDrag.transform;
            otherItemTransform.SetParent(transform);
            otherItemTransform.localPosition = Vector3.zero;
            if(!_isKeeping) GloveTouchedTrigger();
        }    
    }

    public IEnumerator SetText(Text _text, string text)
    {
        Debug.Log("Hehe");
        float time = 5.0f / text.Length;
        Debug.Log($"{time}");
        for (int i = 0; i < text.Length; ++i)
        {
            _text.text = _text.text + text[i];
            Debug.Log($"{_text.text}");
            yield return new WaitForSeconds(time);
        }
    }

    private void Deletting()
    {
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(_glove.GetComponent<Rigidbody2D>());
    }

    void GloveTouchedTrigger()
    {
        Deletting();
        _glove.transform.position = transform.position;

        _isToucheble = _isKeeping = true;

        _gloveImage.GetComponent<Image>().raycastTarget = false;
        _gloveImage.transform.localScale = new Vector2(0.8f, 0.8f);

        _check1.SetActive(true);
        StartCoroutine(SetText(_textAdd1, "В начале базовой проверки врач снимает перчатку с космонавта."));
        _gloveKeeper.SetActive(false);
    }

    public void DeleteSleeve()
    {
        if(_isToucheble)
        {
            audioSource.PlayOneShot(clip);
            _sleeve.transform.position = _sleeveSpawner.transform.position;
            _isToucheble = false;
            StartCoroutine(SetText(_textAdd2, "Теперь врач закатывает рукав. Это часть подготовки к медицинским процедурам."));
            _check2.SetActive(true);
            _button.interactable = true;
        }
    }

    void OnColliderEnter2D(Collider2D collision)
    {
        GloveTouchedTrigger();
    }
}
