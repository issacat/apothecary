using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientScript : MonoBehaviour {
    public GameObject _potion;

    //mixture
    public GameObject[] mixingInventory;
    //mixing arrays
    public GameObject[] m_slots;
    public ArrayList m_ingredients;

    //player
    public GameObject[] playerInventory;
    //player array
    public ArrayList p_ingredients;

    public GameObject banya;
    public GameObject holly;
    public GameObject strength;
    public GameObject soothe;

    // Use this for initialization
    void Start () {
        mixingInventory = GameObject.FindGameObjectsWithTag("mixingInventory");
        playerInventory = GameObject.FindGameObjectsWithTag("playerInventory");
        m_slots = new GameObject[mixingInventory.Length];
        m_ingredients = new ArrayList();
        p_ingredients = new ArrayList();
    }

    void Update()
    {
        for (int i = 0; i < mixingInventory.Length; i++)
        {
            if (mixingInventory[i].gameObject.transform.childCount != 0)
            {
                m_slots[i] = mixingInventory[i].gameObject.transform.GetChild(0).gameObject;
            }
        }
    }

    public void mix()
    {
        bool banyaT = false;
        bool hollyT = false;
        bool strengthT = false;
        bool sootheT = false;

        for (int i = 0; i < mixingInventory.Length; i++)
        {
            if (m_slots[i] != null)
            {
                if (m_slots[i].name == banya.name)  banyaT = true;
                else if (m_slots[i].name == strength.name) strengthT = true;
                else if (m_slots[i].name == soothe.name) sootheT = true;
                else if (m_slots[i].name == holly.name) hollyT = true;
            }
        }

        Debug.Log(banya.name);
        Debug.Log(m_slots[0].name);

        Debug.Log(banyaT);
        Debug.Log(hollyT);
        Debug.Log(sootheT);
        Debug.Log(strengthT);

        if (banyaT == false && hollyT == false && strengthT == true && sootheT == true)
        {
            addPotion(1);
        }
    }

    void addPotion(int i)
    {
        for (int j = 0; j < playerInventory.Length; j++)
        {
            if (playerInventory[j].gameObject.transform.childCount == 0 && 1 == 1)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = (GameObject)Instantiate(_potion);
                a.transform.SetParent(panel.transform, false);
                break;
            }
        }
    }

}
