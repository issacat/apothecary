using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingredientNameGUI : MonoBehaviour {
    //get ingredient
    public GameObject _ingredient;

    public Text ingName;

    // Use this for initialization
    void Start () {
        ingName = GameObject.Find("ingredientName").GetComponent<Text>();
        ingName.text = "inventory";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        if (gameObject.tag == "ingredient")
        {
            _ingredient = gameObject;
            ingName.text = _ingredient.name;
        }
        else
        {
            _ingredient = gameObject;
            ingName.text = _ingredient.name;
        }
    }


    void OnGUI()
    {

    }

    void OnMouseExit()
    {
        ingName.text = "inventory";
    }
}
