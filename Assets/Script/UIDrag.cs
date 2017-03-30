using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour
{
    private Vector3 handleToOriginVector;
    public bool isDragging;

    void OnMouseDown()
    {
        handleToOriginVector = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        transform.root.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + handleToOriginVector;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
