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
    public int bookState = 0;
    public GameObject book;

    //text for UI
    public Text moneyText;
    public Text repText;
    public Text dayText;

    // Use this for initialization
    void Start () {
        book.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        moneyText.text = "Money: " + money.ToString();
        repText.text = "Rep: " + reputation.ToString() + "/100";
        dayText.text = "Day: " + day.ToString();
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
}
