using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bookScript : MonoBehaviour {
    public Image im;

    public GameObject _ingredientPage;
    public GameObject _tomePage;
    public GameObject _recipePage;

    // Use this for initialization
    void Start () {
        im.GetComponent<CanvasRenderer>().SetAlpha(250f);

        _ingredientPage = GameObject.FindGameObjectWithTag("ingredientPage");
        _recipePage = GameObject.FindGameObjectWithTag("recipePage");
        _tomePage = GameObject.FindGameObjectWithTag("tomePage");

        _ingredientPage.SetActive(false);
        _recipePage.SetActive(false);
        _tomePage.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void flipPage()
    {

    }

    public void ingredientSwitch()
    {
        _ingredientPage.SetActive(true);
        _recipePage.SetActive(false);
        _tomePage.SetActive(false);
    }

    public void tomeSwitch()
    {
        _ingredientPage.SetActive(false);
        _recipePage.SetActive(false);
        _tomePage.SetActive(true);
    }

    public void recipeSwitch()
    {
        _ingredientPage.SetActive(false);
        _recipePage.SetActive(true);
        _tomePage.SetActive(false);
    }
}
