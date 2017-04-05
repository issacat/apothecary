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
    public GameObject _placePage;
    public GameObject _menuPage;
    public GameObject _currentPage;

    //get player
    public customerScript _customer;

    //page array
    public GameObject[] ingredientPages;

    //what pages you are on
    public int pageNum = 0;
    private int currMaxPageNum;

    //controls the places accessible
    public int maxPlaces;

    public AudioSource pageFlip;

    // Use this for initialization
    void Start () {
       //  im.GetComponent<CanvasRenderer>().SetAlpha(250f);

        _ingredientPage = GameObject.FindGameObjectWithTag("ingredientPage");
        _recipePage = GameObject.FindGameObjectWithTag("recipePage");
        _tomePage = GameObject.FindGameObjectWithTag("tomePage");
        _peoplePage = GameObject.FindGameObjectWithTag("peoplePage");
        _placePage = GameObject.FindGameObjectWithTag("placePage");
        _menuPage = GameObject.FindGameObjectWithTag("menuPage");

        _currentPage = _tomePage; // set default

        _ingredientPage.SetActive(false);
        _recipePage.SetActive(false);
        _tomePage.SetActive(true);
        _peoplePage.SetActive(false);
        _placePage.SetActive(false);
        _menuPage.SetActive(false);

        maxPlaces = 0;

        pageFlip = GameObject.Find("pageSound").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {


    }

    public void flipPage()
    {
        if (_currentPage == _tomePage|| _currentPage == _menuPage)
        {
            
        }
        else
        {
            if (pageNum < currMaxPageNum - 1)
            {
                pageFlip.clip = Resources.Load<AudioClip>("turnRight");
                pageFlip.Play();
                _currentPage.transform.GetChild(pageNum).gameObject.SetActive(false);
                _currentPage.transform.GetChild(pageNum + 1).gameObject.SetActive(false);
                pageNum += 2;
                _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
                if (pageNum + 1 <= currMaxPageNum)
                {
                    _currentPage.transform.GetChild(pageNum + 1).gameObject.SetActive(true);
                }
            }
        }    
    }

    public void backPage()
    {
        if (pageNum > 1)
        {
            pageFlip.Play();
            _currentPage.transform.GetChild(pageNum).gameObject.SetActive(false);
            if (pageNum + 1 <= currMaxPageNum)
            {
                _currentPage.transform.GetChild(pageNum + 1).gameObject.SetActive(false);
            }
            pageNum -= 2;
            _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
            _currentPage.transform.GetChild(pageNum + 1).gameObject.SetActive(true);
        }
    }

    public void ingredientSwitch()
    {
        pageFlip.clip = Resources.Load<AudioClip>("turnLeft");
        pageFlip.Play();
        _ingredientPage.SetActive(true);
        _recipePage.SetActive(false);
        _tomePage.SetActive(false);
        _peoplePage.SetActive(false);
        _placePage.SetActive(false);
        _menuPage.SetActive(false);

        _currentPage = _ingredientPage;
        currMaxPageNum = _currentPage.transform.childCount-1;
        for (int i = 0; i <= currMaxPageNum; i++)
        {
             _currentPage.transform.GetChild(i).gameObject.SetActive(false);
        }
        pageNum = 0;
        _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
        if(pageNum + 1 <= currMaxPageNum)_currentPage.transform.GetChild(pageNum+1).gameObject.SetActive(true);
    }

    public void tomeSwitch()
    {
        pageFlip.clip = Resources.Load<AudioClip>("turnLeft");
        pageFlip.Play();
        _ingredientPage.SetActive(false);
        _recipePage.SetActive(false);
        _tomePage.SetActive(true);
        _peoplePage.SetActive(false);
        _placePage.SetActive(false);
        _menuPage.SetActive(false);

        _currentPage = GameObject.FindGameObjectWithTag("tomePage");
        currMaxPageNum = _currentPage.transform.childCount-1;
        for (int i = 0; i < currMaxPageNum - 1; i++)
        {
            _currentPage.transform.GetChild(i).gameObject.SetActive(true);
        }
        pageNum = 0;
    }

    public void recipeSwitch()
    {
        pageFlip.clip = Resources.Load<AudioClip>("turnLeft");
        pageFlip.Play();
        _ingredientPage.SetActive(false);
        _recipePage.SetActive(true);
        _tomePage.SetActive(false);
        _peoplePage.SetActive(false);
        _placePage.SetActive(false);
        _menuPage.SetActive(false);

        _currentPage = GameObject.FindGameObjectWithTag("recipePage");
        currMaxPageNum = _currentPage.transform.childCount-1;
        for (int i = 0; i < currMaxPageNum - 1; i++)
        {
            _currentPage.transform.GetChild(i).gameObject.SetActive(false);
        }
        
        if(_customer.charaState == 1)
        {
            pageNum = 0;
        }else pageNum = 1;

        _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
        if (pageNum + 1 <= currMaxPageNum) _currentPage.transform.GetChild(pageNum + 1).gameObject.SetActive(true);
    }

    public void placeSwitch()
    {
        pageFlip.clip = Resources.Load<AudioClip>("turnLeft");
        pageFlip.Play();
        _ingredientPage.SetActive(false);
        _recipePage.SetActive(false);
        _tomePage.SetActive(false);
        _peoplePage.SetActive(false);
        _placePage.SetActive(true);
        _menuPage.SetActive(false);

        _currentPage = _placePage;
        currMaxPageNum = maxPlaces;
        for (int i = 0; i <= _placePage.transform.childCount -1; i++)
        {
            _currentPage.transform.GetChild(i).gameObject.SetActive(false);
        }
        pageNum = 0;
        _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
        if (pageNum + 1 <= currMaxPageNum) _currentPage.transform.GetChild(pageNum + 1).gameObject.SetActive(true);
    }

    public void menuSwitch()
    {
        pageFlip.clip = Resources.Load<AudioClip>("turnLeft");
        pageFlip.Play();
        _ingredientPage.SetActive(false);
        _recipePage.SetActive(false);
        _tomePage.SetActive(false);
        _peoplePage.SetActive(false);
        _placePage.SetActive(false);
        _menuPage.SetActive(true);

        _currentPage = _menuPage;
        currMaxPageNum = _currentPage.transform.childCount - 1;
        for (int i = 0; i < currMaxPageNum - 1; i++)
        {
            _currentPage.transform.GetChild(i).gameObject.SetActive(true);
        }
        pageNum = 0;
    }

    public void peopleSwitch()
    {
        pageFlip.clip = Resources.Load<AudioClip>("turnLeft");
        pageFlip.Play();
        _ingredientPage.SetActive(false);
        _recipePage.SetActive(false);
        _tomePage.SetActive(false);
        _peoplePage.SetActive(true);
        _placePage.SetActive(false);
        _menuPage.SetActive(false);

        _currentPage = GameObject.FindGameObjectWithTag("peoplePage");
        currMaxPageNum = _customer.charaNum;
        for (int i = 0; i <= _peoplePage.transform.childCount -1; i++)
        {
            _currentPage.transform.GetChild(i).gameObject.SetActive(false);
        }
        pageNum = 0;
        _currentPage.transform.GetChild(pageNum).gameObject.SetActive(true);
        if (pageNum + 1 <= currMaxPageNum) _currentPage.transform.GetChild(pageNum + 1).gameObject.SetActive(true);
    }
}
