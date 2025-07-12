using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Gameruler : MonoBehaviour
{
    public TMP_Text _txt;
    public GameObject _spawner;
    void Start()
    {
        _txt.transform.position = _spawner.transform.position;
    }
}
