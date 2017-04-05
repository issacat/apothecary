using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingredientNameGUI : MonoBehaviour {
    //get ingredient
    public GameObject _ingredient;

    public Text ingName;
    public Text ingAtt;

    public ingredientScript ingScript;

    // Use this for initialization
    void Start () {
        ingName = GameObject.Find("ingredientName").GetComponent<Text>();
        ingName.text = "inventory";

        ingAtt = GameObject.Find("ingredientAttribute").GetComponent<Text>();
        ingAtt.text = " ";

        ingScript = GameObject.Find("preparationArea").GetComponent<ingredientScript>();
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
            ingAtt.text = ingScript.ingredients[_ingredient.name].attribute;
        } else if (gameObject.tag == "potion")
        {
            _ingredient = gameObject;
            ingName.text = _ingredient.name;
            ingAtt.text = _ingredient.GetComponent<potionAttribute>().attribute;
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
        ingAtt.text = " ";
    }
}
