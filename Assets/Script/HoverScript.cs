using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour {

    // mouse control
    public int cursorSize = 32;
    public Texture2D defaultTexture;
    public Texture2D hoverItemTexture;
    public CursorMode curMode = CursorMode.Auto;
    public bool autoCenterHotSpot = true;
    public Vector2 hotSpotCustom = Vector2.zero;
    private Vector2 hotSpotAuto;

    // Use this for initialization
    void Start () {
        Vector2 hotSpot;
        if (autoCenterHotSpot)
        {
            hotSpotAuto = new Vector2(defaultTexture.width * 0.5f, defaultTexture.height * 0.5f);
            hotSpot = hotSpotAuto;

        }
        else { hotSpot = hotSpotCustom; }

        Cursor.SetCursor(defaultTexture, hotSpot, CursorMode.ForceSoftware);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(Event.current.mousePosition.x - (cursorSize / 2), Event.current.mousePosition.y - (cursorSize / 2), cursorSize, cursorSize), cursorTex);
    }

    void OnMouseEnter()
    {
        //Debug.Log("random");
        if (gameObject.tag == "ingredient")
        {
            Cursor.SetCursor(hoverItemTexture, hotSpotCustom, CursorMode.ForceSoftware);
           // Debug.Log("hovering over an ingredient!");
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultTexture, hotSpotCustom, CursorMode.ForceSoftware);
    }
}
