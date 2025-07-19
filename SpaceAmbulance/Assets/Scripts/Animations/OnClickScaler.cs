using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class OnClickScaler : MonoBehaviour
{
    public GameObject _button;

    public void Scaler()
    {
        RectTransform _tr = _button.GetComponent<RectTransform>();
        _tr.DOComplete();
        _tr.DOPunchScale(Vector3.one * -0.2f, 0.2f, 1);
        //_tr.DOSizeDelta(new Vector2(_tr.rect.width / 1.25f, _tr.rect.height / 1.25f), .3f);
    }
}
