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

        _text.text = "Скафандр «Сокол» — лёгкий спасательный скафандр. Защищает от разгерметизации, перегрузок и температур при запуске и спуске. Не предназначен для выхода в открытый космос. Перчатки и рукава удобны для базовой проверки.";
    }

    public void Pulse()
    {
        for (int i = 0; i < _buttons.Length; ++i)
            _buttons[i].transform.localScale = _localButtonsScales[i];
        _buttons[1].transform.localScale *= scale;
        _text.text = "Пульсометр. В норме у человека пульс                     в границе между 60 и 80 ударами в минуту.         У космонавтов он бывает выше из-за длительного пребывания в невесомости.";
    }

    public void Taho()
    {
        for (int i = 0; i < _buttons.Length; ++i)
            _buttons[i].transform.localScale = _localButtonsScales[i];
        _buttons[2].transform.localScale *= scale;
        _text.text = "Тонометр измеряет давление, норма для человека — 120 на 80. У космонавтов после возвращения на землю артериальное давление может упасть. Под влиянием гравитации кровь начинает снова стекать             в ноги и живот. Поэтому сердце получает меньше крови для артерий.";
    }

    public void Med()
    {
        for (int i = 0; i < _buttons.Length; ++i)
            _buttons[i].transform.localScale = _localButtonsScales[i];
        _buttons[3].transform.localScale *= scale;
        _text.text = "Врач поисково-спасательной службы (ПСС) осматривает космонавтов сразу после посадки. Это называется базовая проверка.        Её всегда проводят в полевых условиях. После космонавт попадает в медицинскую палатку для медико-биологического обследования.";
    }
}
