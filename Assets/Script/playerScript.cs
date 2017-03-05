using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {
    //resources the player has
    public int money = 500;
    public int reputation = 50;

    //controls if inventory and book are visible
    public int invState = 1;
    public int bookState = 0;
    public GameObject inventory;
    public GameObject book;

    //text for UI
    public Text moneyText;
    public Text repText;

    // Use this for initialization
    void Start () {
        inventory.SetActive(true);
        book.SetActive(false);

        moneyText.text = "Money: " + money.ToString();
        repText.text = "Rep: " + reputation.ToString() + "/100";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleInventory()
    {
        if (invState == 1)
        {
            invState = 0;
            inventory.SetActive(false);
        }
        else if (invState == 0)
        {
            invState = 1;
            inventory.SetActive(true);            
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

    public void changeInventoryState(int z)
    {
        invState = z;
        toggleInventory();
    }
}
