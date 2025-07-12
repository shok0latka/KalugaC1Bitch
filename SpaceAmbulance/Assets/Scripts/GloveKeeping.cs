using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class GloveKeeping : MonoBehaviour, IDropHandler
{
    public GameObject _glove;
    public GameObject _gloveKeeper;
    public GameObject _gloveImage;
    public TMP_Text _txt;
    public GameObject _spawner;
    public TMP_Text _txtLast;

    public bool _isToucheble = false;
    public bool _isKeeping = false;
    public GameObject _sleeve;
    public GameObject _sleeveSpawner;

    public GameObject _check;


    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        otherItemTransform.SetParent(transform);
        otherItemTransform.localPosition = Vector3.zero;
        if(!_isKeeping) GloveTouchedTrigger();
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
        _txt.transform.position = _spawner.transform.position;
        _txtLast.transform.position = new Vector2(6000, 6000);
        _isToucheble = _isKeeping = true;
        _gloveImage.GetComponent<Image>().raycastTarget = false;
        _gloveImage.transform.localScale = new Vector2(0.8f, 0.8f);
    }

    public void DeleteSleeve()
    {
        if(_isToucheble)
        {
            _sleeve.transform.position = _sleeveSpawner.transform.position;
            _isToucheble = false;
            _check.SetActive(true);
            _txt.transform.position = new Vector2(6000, 6000);
        }
    }

    void OnColliderEnter2D(Collider2D collision)
    {
        GloveTouchedTrigger();
    }
}
