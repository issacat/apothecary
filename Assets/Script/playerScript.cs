using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {
    //resources the player has
    public int money = 500;
    public int reputation = 50;
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
    public Text repText;
    public Text dayText;

    public GameObject[] tags;

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
    }
	
	// Update is called once per frame
	void Update () {
        repText.text = "Rep: " + reputation.ToString() + "/100";
        dayText.text = "Day: " + day.ToString();
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
}
