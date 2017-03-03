using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PresentScreen
{
    storeMode,
    preparationMode
}


public class storyScript : MonoBehaviour {
    public static PresentScreen screen;

    public GameObject _storeMode;
    public GameObject _preparationMode;

    void Awake()
    {
        _storeMode = GameObject.FindGameObjectWithTag("storeFront");
        _preparationMode = GameObject.FindGameObjectWithTag("prepArea");
    }

    // Use this for initialization
    void Start () {
        screen = PresentScreen.storeMode;
    }
	
	// Update is called once per frame
	void Update () {
        if (screen == PresentScreen.storeMode)
        {
           // Debug.Log("we are in the store");

            _storeMode.SetActive(true);
            _preparationMode.SetActive(false);
        }

        if (screen == PresentScreen.preparationMode)
        {
           // Debug.Log("we are in preparations");

            _storeMode.SetActive(false);
            _preparationMode.SetActive(true);
        }
    }

    public void switchStore()
    {
        screen = PresentScreen.storeMode;
    }

    public void switchPrepare()
    {
        screen = PresentScreen.preparationMode;

    }

    public void rightButton()
    {
        if (screen == PresentScreen.storeMode)
        {
            screen = PresentScreen.preparationMode;
        }


        else if (screen == PresentScreen.preparationMode)
        {
            screen = PresentScreen.storeMode;
        }
    }

    public void leftButton()
    {
        if (screen == PresentScreen.storeMode)
        {
            screen = PresentScreen.preparationMode;
        }


        else if (screen == PresentScreen.preparationMode)
        {
            screen = PresentScreen.storeMode;
        }
    }
}
