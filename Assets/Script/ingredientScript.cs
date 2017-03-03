using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientScript : MonoBehaviour {
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

    public GameObject potionA;
    public GameObject potionB;
    public GameObject potionC;
    public GameObject banyaPotion;

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
            else m_slots[i] = null;
        }
    }

    public void mix()
    {
        bool banyaT = false;
        bool hollyT = false;
        bool strengthT = false;
        bool sootheT = false;

        for (int i = 0; i < m_slots.Length; i++)
        {
            if (m_slots[i] != null)
            {
                if (m_slots[i].name == banya.name)  banyaT = true;
                else if (m_slots[i].name == strength.name) strengthT = true;
                else if (m_slots[i].name == soothe.name) sootheT = true;
                else if (m_slots[i].name == holly.name) hollyT = true;
            }
        }

        Debug.Log(banyaT);
        Debug.Log(hollyT);
        Debug.Log(sootheT);
        Debug.Log(strengthT);

        if (banyaT == false && hollyT == false && strengthT == true && sootheT == true)
        {
            addPotion(1);
        } else if (banyaT == false && hollyT == true && strengthT == true && sootheT == true)
        {
            addPotion(2);
        } else if (banyaT == true && hollyT == false && strengthT == false && sootheT == true)
        {
            addPotion(3);
        } else if (banyaT == true && hollyT == true && strengthT == false && sootheT == true)
        {
            addPotion(4);
        }
    }

    void addPotion(int type)
    {
        for (int j = 0; j < playerInventory.Length; j++)
        {
            if (playerInventory[j].gameObject.transform.childCount == 0 && type == 1)
            {
                Transform panel = playerInventory[j].transform;
               
                GameObject a = (GameObject)Instantiate(potionA);
                a.transform.SetParent(panel.transform, false);
                for (int h = 0; h < m_slots.Length; h++)
                {
                    if (m_slots[h] != null)
                    {
                        Destroy(m_slots[h]);
                    }
                }
                break;
            }

            else if (playerInventory[j].gameObject.transform.childCount == 0 && type == 2)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = (GameObject)Instantiate(potionB);
                a.transform.SetParent(panel.transform, false);
                for (int h = 0; h < m_slots.Length; h++)
                {
                    if (m_slots[h] != null)
                    {
                        Destroy(m_slots[h]);
                    }
                }
                break;
            }

            else if (playerInventory[j].gameObject.transform.childCount == 0 && type == 3)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = (GameObject)Instantiate(banyaPotion);
                a.transform.SetParent(panel.transform, false);
                for (int h = 0; h < m_slots.Length; h++)
                {
                    if (m_slots[h] != null)
                    {
                        Destroy(m_slots[h]);
                    }
                }
                break;
            }

            else if (playerInventory[j].gameObject.transform.childCount == 0 && type == 4)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = (GameObject)Instantiate(potionC);
                a.transform.SetParent(panel.transform, false);
                for (int h = 0; h < m_slots.Length; h++)
                {
                    if (m_slots[h] != null)
                    {
                        Destroy(m_slots[h]);
                    }
                }
                break;
            }
        }
    }

}
