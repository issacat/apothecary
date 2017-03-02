using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customerDialog : MonoBehaviour
{
    public int state = 0; //state determines what the merchant is saying

    public Text dialogText;

    string dialogString;

    // Use this for initialization
    void Start()
    {
        dialogText = GameObject.Find("DialogText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        dialogText.text = dialogString;

        if (state == 0)
        {
            dialogString = "Hello shopkeeper! I have to go pick magical mushrooms at night in the forest.";
        }

        if (state == 1)
        {
            dialogString = "I'm a bit scared. Can you give me something to help me with this?";
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
