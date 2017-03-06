using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientNameGUI : MonoBehaviour {
    private string currentToolTipText = "";
    private GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack;

    //get ingredient
    public GameObject _ingredient;

    // Use this for initialization
    void Start () {
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        guiStyleFore.alignment = TextAnchor.UpperCenter;
        guiStyleFore.wordWrap = true;
        guiStyleFore.font = (Font)Resources.Load("GenBasR");
        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.font = (Font)Resources.Load("GenBasR");
        guiStyleBack.wordWrap = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        if (gameObject.tag == "ingredient")
        {
            _ingredient = gameObject;
            currentToolTipText = _ingredient.name;
        }

    }


    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(Event.current.mousePosition.x - (cursorSize / 2), Event.current.mousePosition.y - (cursorSize / 2), cursorSize, cursorSize), cursorTex);
        if (currentToolTipText != "")
        {
            var x = Event.current.mousePosition.x;
            var y = Event.current.mousePosition.y;
            GUI.Label(new Rect(x - 145, y + 25, 300, 60), currentToolTipText, guiStyleBack);
            GUI.Label(new Rect(x - 144, y + 25, 300, 60), currentToolTipText, guiStyleFore);
        }
    }

    void OnMouseExit()
    {
        currentToolTipText = "";
    }
}
