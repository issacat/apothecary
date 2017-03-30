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

    public GameObject[] tags;

    //modal objects
    public GameObject modal;
    public GameObject endModal;

    public GameObject gratText;

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
    }
	
	// Update is called once per frame
	void Update () {
        dayText = GameObject.FindGameObjectsWithTag("dayText");
        for (int i = 0; i < dayText.Length; i++)
        {
            dayText[i].GetComponent<Text>().text = "Day: " + day.ToString(); ; 
        }
        gratText = GameObject.Find("gratitudeText");
        gratText.GetComponent<Text>().text ="Gratitude: " + gratitude.ToString();
    }

    public void toggleItem()
    {
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
        if (bookState == 1)
        {
            bookState = 0;
            book.SetActive(false);
        }
        else if (bookState == 0)
        {
            bookState = 1;
            book.SetActive(true);
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
            bookState = 1;
            book.SetActive(true);
            itemState = 1;
            item.SetActive(true);
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

    public void modalPopUp(string s, Sprite img)
    {
        modal.SetActive(true);
        Text text = modal.GetComponentInChildren<Text>();
        text.text = s;

        SpriteRenderer spr = modal.GetComponentInChildren<SpriteRenderer>();
        spr.sprite = img;
    }

    public void closeModal()
    {
        modal.SetActive(false);
    }

    public void endModalPopUp()
    {
        endModal.SetActive(true);
    }

    public void closeEndModal()
    {
        endModal.SetActive(false);
    }
}
