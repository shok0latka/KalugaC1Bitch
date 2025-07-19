using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PulseKeeper : MonoBehaviour, IDropHandler
{

    public Image _pulseImage;
    public GameObject _pulsePose;
    public GameObject _pulse;
    public Image _naPalec;

    public GameObject QTEManager;

    public AudioSource audioSource;
    public AudioClip clip;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.tag == "Pulse")
        {
            audioSource.PlayOneShot(clip);
            var otherItemTransform = eventData.pointerDrag.transform;
            otherItemTransform.SetParent(transform);
            _pulse.SetActive(false);
            _pulseImage.GetComponent<Image>().raycastTarget = false;
            _naPalec.transform.localPosition = _pulsePose.transform.localPosition;
            StartCoroutine(QTEManager.GetComponent<QuickTimeEvents>().MultiButton());
        }
    }
}
