using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {
    //resources the player has
    public int gratitude = 0;
    public int day = 1;

    //controls and book are visible
    public int bookState = 1;
    public GameObject book;

    //controls and book are visible
    public int itemState = 1;
    public GameObject item;

    //controls and book are visible
    public int UIState = 1;
    public GameObject[] UI;

    //text for UI
    public GameObject[] dayText;
    public GameObject gratText;
    public GameObject[] tags;

    //modal objects
    public GameObject modal;
    public GameObject endModal;

    //trash
    public GameObject[] t_slot;

    //animation apothecary
    public Animator anim;
    public GameObject bookButton;
    public GameObject apothecary;

    public AudioSource sounds;
    public AudioSource trashSound;

    // Use this for initialization
    void Start () {
        bookState = 1;
        book.SetActive(true);

        itemState = 1;
        item.SetActive(true);

        UIState = 1;
        UI = GameObject.FindGameObjectsWithTag("UI");
        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(true);
        }

        tags = GameObject.FindGameObjectsWithTag("tomeTags");
        for (int i = 0; i < tags.Length; i++)
        {
            tags[i].SetActive(false);
        }

        modal = GameObject.FindGameObjectWithTag("modal");
        modal.SetActive(false);

        endModal = GameObject.FindGameObjectWithTag("endModal");
        endModal.SetActive(false);

        t_slot = GameObject.FindGameObjectsWithTag("trash");

        anim = GameObject.Find("Apothecary").GetComponent<Animator>();
        apothecary = GameObject.Find("Apothecary");
        bookButton = GameObject.Find("book button");

        anim.SetBool("bookBool", true);
        bookButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("char_apothecary_closed_1");

        itemState = 0;
        item.SetActive(false);

        trashSound = GameObject.Find("trashSound").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        dayText = GameObject.FindGameObjectsWithTag("dayText");
        for (int i = 0; i < dayText.Length; i++)
        {
            dayText[i].GetComponent<Text>().text = "Day: " + day.ToString(); ; 
        }
       // gratText = GameObject.Find("gratitudeText");
       // gratText.GetComponent<Text>().text ="Gratitude: " + gratitude.ToString();
    }

    public void toggleItem()
    {
        sounds = GameObject.Find("UISound").GetComponent<AudioSource>();
        sounds.clip = Resources.Load<AudioClip>("click");
        sounds.Play();
        if (itemState == 1)
        {
            itemState = 0;
            item.SetActive(false);
        }
        else if (itemState == 0)
        {
            itemState = 1;
            item.SetActive(true);
        }
    }

    public void toggleBook()
    {
        sounds = GameObject.Find("UISound").GetComponent<AudioSource>();
        sounds.clip = Resources.Load<AudioClip>("turnLeft");
        sounds.Play();
        if (bookState == 1)
        {
            bookState = 0;
            book.SetActive(false);
            bookButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("char_apothecary_closed_1");
            anim.SetBool("bookBool", false);
            apothecary.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("char_apothecary_closed_1");
        }
        else if (bookState == 0)
        {
            bookState = 1;
            book.SetActive(true);
            if(book.GetComponent<bookScript>()._currentPage == book.GetComponent<bookScript>()._ingredientPage)
            {
                book.GetComponent<bookScript>().ingredientSwitch();
            }else if (book.GetComponent<bookScript>()._currentPage == book.GetComponent<bookScript>()._recipePage)
            {
                book.GetComponent<bookScript>().recipeSwitch();
            }
            else if (book.GetComponent<bookScript>()._currentPage == book.GetComponent<bookScript>()._peoplePage)
            {
                book.GetComponent<bookScript>().peopleSwitch();
            }
            else if (book.GetComponent<bookScript>()._currentPage == book.GetComponent<bookScript>()._placePage)
            {
                book.GetComponent<bookScript>().placeSwitch();
            }
            bookButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("char_apothecary_open_1");
            anim.SetBool("bookBool", true);
            apothecary.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("char_apothecary_open_1");
        }
    }

    public void togglePlayer()
    {
        if (UIState == 1)
        {
            UIState = 0;
            for (int i = 0; i < UI.Length; i++)
            {
                UI[i].SetActive(false);       
            }
            bookState = 0;
            book.SetActive(false);
            itemState = 0;
            item.SetActive(false);
        }
        else if (UIState == 0)
        {
            UIState = 1;
            for (int i = 0; i < UI.Length; i++)
            {
                UI[i].SetActive(true);
            }
        }
    }

    public void turnOffTags()
    {
        for (int i = 0; i < tags.Length; i++)
        {
            tags[i].SetActive(false);
        }
    }

    public void turnOnTags()
    {
        for (int i = 0; i < tags.Length; i++)
        {
            tags[i].SetActive(true);
        }
    }

    public void modalPopUp(string s, string a, Sprite img)
    {
        modal.SetActive(true);
        Text text = GameObject.Find("modal ingredient").GetComponent<Text>();
        text.text = s;

        Text text2 = GameObject.Find("modal attribute").GetComponent<Text>();
        text2.text = a;

        SpriteRenderer spr = modal.GetComponentInChildren<SpriteRenderer>();
        spr.sprite = img;
    }

    public void closeModal()
    {
        modal.SetActive(false);
    }

    public void endModalPopUp()
    {
        if (endModal.activeSelf)
        {
            closeEndModal();
        }else
        {
        endModal.SetActive(true);

        }
        sounds.clip = Resources.Load<AudioClip>("click");
        sounds.Play();
    }

    public void closeEndModal()
    {
        endModal.SetActive(false);
        sounds.clip = Resources.Load<AudioClip>("click");
        sounds.Play();
    }

    public void nextDay()
    {
        endModal.SetActive(false);
        itemState = 0;
        item.SetActive(false);
        bookState = 0;
        book.SetActive(false);
    }

    public void trash()
    {
        trashSound.Play();
        for (int i = 0; i < t_slot.Length; i++)
        {
            if (t_slot[i].transform.childCount != 0)
            {
                Destroy(t_slot[i].transform.GetChild(0).gameObject);
            }
        }  
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
