using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionAttribute : MonoBehaviour
{
    public string ingredientName;
    public string attribute;
    public string description;
    public Sprite img;

    public potionAttribute(string i, string a, string d, Sprite s)
    {
        ingredientName = i;
        attribute = a;
        description = d;
        img = s;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setAttribute(string s)
    {
        attribute = s;
    }
}
