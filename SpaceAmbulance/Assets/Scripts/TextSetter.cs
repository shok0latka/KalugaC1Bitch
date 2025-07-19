using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextSetter : MonoBehaviour
{
    public TMP_Text _text; // text in scene "titry"

    public GameObject[] _buttons; // array of buttons in scene "titry"

    public float scale = 1.2f; // scale buttons on click

    Vector3[] _localButtonsScales; // scale of buttons before changing

    // Save all scales
    void Start()
    {
        _localButtonsScales = new Vector3[_buttons.Length];
        for (int i = 0; i < _buttons.Length; ++i)
            _localButtonsScales[i] = _buttons[i].transform.localScale;
    }

    // Set all scales back, use new scale for pressed button and changing text
    public void Glove()
    {
        for(int i = 0; i < _buttons.Length; ++i)
            _buttons[i].transform.localScale = _localButtonsScales[i];
        _buttons[0].transform.localScale *= scale;

        _text.text = "�������� ������ � ����� ������������ ��������. �������� �� ���������������, ���������� � ���������� ��� ������� � ������. �� ������������ ��� ������ � �������� ������. �������� � ������ ������ ��� ������� ��������.";
    }

    public void Pulse()
    {
        for (int i = 0; i < _buttons.Length; ++i)
            _buttons[i].transform.localScale = _localButtonsScales[i];
        _buttons[1].transform.localScale *= scale;
        _text.text = "����������. � ����� � �������� �����                     � ������� ����� 60 � 80 ������� � ������.         � ����������� �� ������ ���� ��-�� ����������� ���������� � �����������.";
    }

    public void Taho()
    {
        for (int i = 0; i < _buttons.Length; ++i)
            _buttons[i].transform.localScale = _localButtonsScales[i];
        _buttons[2].transform.localScale *= scale;
        _text.text = "�������� �������� ��������, ����� ��� �������� � 120 �� 80. � ����������� ����� ����������� �� ����� ������������ �������� ����� ������. ��� �������� ���������� ����� �������� ����� �������             � ���� � �����. ������� ������ �������� ������ ����� ��� �������.";
    }

    public void Med()
    {
        for (int i = 0; i < _buttons.Length; ++i)
            _buttons[i].transform.localScale = _localButtonsScales[i];
        _buttons[3].transform.localScale *= scale;
        _text.text = "���� ��������-������������ ������ (���) ����������� ����������� ����� ����� �������. ��� ���������� ������� ��������.        Ÿ ������ �������� � ������� ��������. ����� ��������� �������� � ����������� ������� ��� ������-�������������� ������������.";
    }
}
