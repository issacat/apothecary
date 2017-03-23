using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour
{

   public bool isPicked;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {

            isPicked = false;
        }

        if (isPicked == true)
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = mousePos;

            // if you want to smooth movement then lerp it

        }

    }

    void OnMouseDown()
    {

        isPicked = true;

    }

}
