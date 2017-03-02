using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialog : MonoBehaviour {
    public int state = 0; //state determines what the merchant is saying

    public Text dialogText;

    string dialogString;

	// Use this for initialization
	void Start () {
        dialogText = GameObject.Find("DialogText").GetComponent<Text>();
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
            dialogString = "I've heard that the plague is spreading in the north.";
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
