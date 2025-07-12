using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GloveKeeping : MonoBehaviour
{
    public GameObject _glove;
    public GameObject _gloveKeeper;
    public TMP_Text _txt;
    public GameObject _spawner;
    public TMP_Text _txtLast;

    public bool _isToucheble = false;
    public bool _isKeeping = false;
    public GameObject _sleeve;
    public GameObject _sleeveSpawner;

    public GameObject _check;

    private void Deletting()
    {
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(_glove.GetComponent<Rigidbody2D>());
        Destroy(_glove.GetComponent<TouchDrag2D>());
    }

    void GloveTouchedTrigger()
    {
        Deletting();
        _glove.transform.position = transform.position;
        _txt.transform.position = _spawner.transform.position;
        _txtLast.transform.position = new Vector2(6000, 6000);
        _isToucheble = _isKeeping = true;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        GloveTouchedTrigger();
    }
}
