using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TahometrKeeper : MonoBehaviour, IDropHandler
{
    public Image _tahoImage;

    public GameObject QTEManager;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.tag == "Taho")
        {
            var otherItemTransform = eventData.pointerDrag.transform;
            otherItemTransform.SetParent(transform);
            otherItemTransform.localPosition = Vector3.zero;

            _tahoImage.GetComponent<Image>().raycastTarget = false;

            QTEManager.GetComponent<QuickTimeEvents>().StartCoroutine(QTEManager.GetComponent<QuickTimeEvents>().OneButton());
        }
    }
}
