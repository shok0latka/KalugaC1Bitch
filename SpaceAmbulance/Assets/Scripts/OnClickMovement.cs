using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class OnClickMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Canvas _mainCanvas;
    private CanvasGroup _canvasGroup;
    private RectTransform _rect;


    void Start()
    {
        _rect = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _mainCanvas = GetComponentInParent<Canvas>().rootCanvas;
    }

    public void OnBeginDrag(PointerEventData eventData) => _canvasGroup.blocksRaycasts = false;

    public void OnDrag(PointerEventData eventData) => _rect.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.DOMove(transform.parent.transform.position, 1.0f);
        _canvasGroup.blocksRaycasts = true;
    }
}
