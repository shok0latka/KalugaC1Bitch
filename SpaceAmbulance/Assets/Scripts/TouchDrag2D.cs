using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Collider2D))] // ������� ������� ����������
public class TouchDrag2D : MonoBehaviour
{
    public GameObject _glove;
    private Vector3 touchOffset;
    private float zCoordinate;
    private bool isDragging = false;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (IsTouchOnObject(touchPosition))
                    {
                        _glove.AddComponent<Rigidbody2D>();
                        StartDragging(touchPosition);
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        DragObject(touchPosition);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isDragging = false;
                    break;
            }
        }
    }

    private bool IsTouchOnObject(Vector2 touchPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            mainCamera.ScreenToWorldPoint(touchPosition),
            Vector2.zero);
        
        return hit.collider && hit.transform == transform;
    }

    private void StartDragging(Vector2 touchPosition)
    {
        zCoordinate = mainCamera.WorldToScreenPoint(transform.position).z;
        touchOffset = transform.position - GetWorldPosition(touchPosition);
        isDragging = true;
    }

    private void DragObject(Vector2 touchPosition)
    {

        transform.position = GetWorldPosition(touchPosition) + touchOffset;
    }

    private Vector3 GetWorldPosition(Vector2 touchPosition)
    {
        Vector3 touchWorldPosition = mainCamera.ScreenToWorldPoint(
            new Vector3(touchPosition.x, touchPosition.y, zCoordinate));
        return touchWorldPosition;
    }
}