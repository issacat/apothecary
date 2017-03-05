using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bookScript : MonoBehaviour {
    public Image im;

    public GameObject _ingredientPage;
    public GameObject _tomePage;
    public GameObject _recipePage;
    public GameObject _peoplePage;
    private GameObject _currentPage;

    //get player
    public customerScript _customer;

    //page array
    public GameObject[] ingredientPages;

    //what pages you are on
    public int pageNum = 0;
    private int currMaxPageNum;

    // Use this for initialization
    void Start () {
       //  im.GetComponent<CanvasRenderer>().SetAlpha(250f);

        _ingredientPage = GameObject.FindGameObjectWithTag("ingredientPage");
        _recipePage = GameObject.FindGameObjectWithTag("recipePage");
        _tomePage = GameObject.FindGameObjectWithTag("tomePage");
        _peoplePage = GameObject.FindGameObjectWithTag("peoplePage");

        _currentPage = _tomePage; // set default

        _ingredientPage.SetActive(false);
        _recipePage.SetActive(false);
        _tomePage.SetActive(true);
        _peoplePage.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (_currentPage.name == _ingredientPage.name && _customer.charaState == 1)
        {
            currMaxPageNum = _currentPage.transform.childCount - 5;
        }else if (_currentPage.name == _ingredientPage.name && _customer.charaState == 2)
        {
            currMaxPageNum = _currentPage.transform.childCount - 4;

        }
        else
        {
            currMaxPageNum = _currentPage.transform.childCount - 3;
        }
    }

    public void flipPage()
    {
        if (pageNum < currMaxPageNum)
        {
            _currentPage.transform.GetChild(pageNum).gameObject.SetActive(false);
            pageNum++;
            _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
        }
    }

    public void backPage()
    {
        if (pageNum > 0)
        {
            _currentPage.transform.GetChild(pageNum).gameObject.SetActive(false);
            pageNum--;
            _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
        }
    }

    public void ingredientSwitch()
    {
        _ingredientPage.SetActive(true);
        _recipePage.SetActive(false);
        _tomePage.SetActive(false);
        _peoplePage.SetActive(false);

        _currentPage = _ingredientPage;
        currMaxPageNum = _currentPage.transform.childCount - 2;
        for (int i = 0; i < currMaxPageNum; i++)
        {
             _currentPage.transform.GetChild(i).gameObject.SetActive(false);
        }
        pageNum = 0;
        _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
    }

    public void tomeSwitch()
    {
        _ingredientPage.SetActive(false);
        _recipePage.SetActive(false);
        _tomePage.SetActive(true);
        _peoplePage.SetActive(false);

        _currentPage = GameObject.FindGameObjectWithTag("tomePage");
        currMaxPageNum = _currentPage.transform.childCount - 3;
        for (int i = 0; i < currMaxPageNum - 1; i++)
        {
            _currentPage.transform.GetChild(i).gameObject.SetActive(false);
        }
        pageNum = 0;
        _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
    }

    public void recipeSwitch()
    {
        _ingredientPage.SetActive(false);
        _recipePage.SetActive(true);
        _tomePage.SetActive(false);
        _peoplePage.SetActive(false);

        _currentPage = GameObject.FindGameObjectWithTag("recipePage");
        currMaxPageNum = _currentPage.transform.childCount - 3;
        for (int i = 0; i < currMaxPageNum - 1; i++)
        {
            _currentPage.transform.GetChild(i).gameObject.SetActive(false);
        }
        pageNum = 0;
        _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
    }

    public void peopleSwitch()
    {
        _ingredientPage.SetActive(false);
        _recipePage.SetActive(false);
        _tomePage.SetActive(false);
        _peoplePage.SetActive(true);

        _currentPage = GameObject.FindGameObjectWithTag("peoplePage");
        currMaxPageNum = _currentPage.transform.childCount - 3;
        for (int i = 0; i < currMaxPageNum - 1; i++)
        {
            _currentPage.transform.GetChild(i).gameObject.SetActive(false);
        }
        pageNum = 0;
        _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
    }
}
