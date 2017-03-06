using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class merchantScript : MonoBehaviour {
    public int state = 0; //state determines what the merchant is saying

    public Text dialogText;

    string dialogString;

    public GameObject[] merchantInventory;
    public GameObject banya;
    public GameObject holly;
    public GameObject strength;
    public GameObject soothe;

    bool banyaT;
    bool hollyT;
    bool strengthT;
    bool sootheT;

    // Use this for initialization
    void Start () {
        dialogText = GameObject.Find("DialogText").GetComponent<Text>();
        merchantInventory = GameObject.FindGameObjectsWithTag("merchantInventory");

        banya = (GameObject)Resources.Load("Banya");
        holly = (GameObject)Resources.Load("Holly");
        strength = (GameObject)Resources.Load("Strength");
        soothe = (GameObject)Resources.Load("Soothe"); 
    }
	
	// Update is called once per frame
	void Update () {
        dialogText.text = dialogString;

        if (state == 0)
        {
            dialogString = "Welcome! What can I get you today?";
        }

        if (state == 1)
        {
            dialogString = "I've heard many good things from you.";
        }
	}

    public void checkIngredient()
    {
        banyaT = false;
        hollyT = false;
        strengthT = false;
        sootheT = false;

        for (int i = 0; i < merchantInventory.Length; i++)
        {
            if (merchantInventory[i].gameObject.transform.childCount != 0)
            {
                //Debug.Log(merchantInventory[i].transform.GetChild(0).name);
                /*if (merchantInventory[i].transform.GetChild(0).name.Contains(banya.name)) banyaT = true;
                else */ if (merchantInventory[i].transform.GetChild(0).name.Contains(strength.name)) strengthT = true;
                else if (merchantInventory[i].transform.GetChild(0).name.Contains(soothe.name)) sootheT = true;
                else if (merchantInventory[i].transform.GetChild(0).name.Contains(holly.name)) hollyT = true;
            }
        }

       /* if (banyaT == false)
        {
            addIngredient("banya");
        }*/
        if (hollyT == false)
        {
            addIngredient("holly");
        }
        if (strengthT == false)
        {
            addIngredient("strength");
        }
        if (sootheT == false)
        {
            addIngredient("soothe");
        }
    }

    public void addIngredient(string ing)
    {
        for (int j = 0; j < merchantInventory.Length; j++)
        {
            if (merchantInventory[j].gameObject.transform.childCount == 0)
            {
                if (ing == "banya")
                {
                    Transform panel = merchantInventory[j].transform;
                    GameObject a = (GameObject)Instantiate(Resources.Load("Banya"));
                    a.name = a.name.Replace("(Clone)", "");
                    a.transform.SetParent(panel.transform, false);
                }else if (ing == "holly")
                {
                    Transform panel = merchantInventory[j].transform;
                    GameObject a = (GameObject)Instantiate(Resources.Load("Holly"));
                    a.name = a.name.Replace("(Clone)", "");
                    a.transform.SetParent(panel.transform, false);
                }
                else if (ing == "strength")
                {
                    Transform panel = merchantInventory[j].transform;
                    GameObject a = (GameObject)Instantiate(Resources.Load("Strength"));
                    a.name = a.name.Replace("(Clone)", "");
                    a.transform.SetParent(panel.transform, false);
                }
                else if (ing == "soothe")
                {
                    Transform panel = merchantInventory[j].transform;
                    GameObject a = (GameObject)Instantiate(Resources.Load("Soothe"));
                    a.name = a.name.Replace("(Clone)", "");
                    a.transform.SetParent(panel.transform, false);
                }
                break;

            }
        }
    }

    public void moveForward()
    {
        if (state == 0)
        {
            state = 1;
        }

        else if (state == 1)
        {
            state = 0;
        }
    }
}
