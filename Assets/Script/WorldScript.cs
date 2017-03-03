using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuState
{
    mainMenu,
    introMode,
    merchantMode,
    storyMode
}

public class WorldScript : MonoBehaviour {
    public static MenuState menuState;

    public GameObject _mainMenuMode;
    public GameObject _introMode;
    public GameObject _merchantMode;
    public GameObject _player;
    public GameObject _storyMode;

    public playerScript player;

    void Awake()
    {
        _mainMenuMode = GameObject.FindGameObjectWithTag("mainMenuMode");
        _introMode = GameObject.FindGameObjectWithTag("introduction");
        _merchantMode = GameObject.FindGameObjectWithTag("merchantMode");
        _player = GameObject.FindGameObjectWithTag("Player");
        _storyMode = GameObject.FindGameObjectWithTag("storyMode");

        _introMode.SetActive(false);
        _merchantMode.SetActive(false);
        _player.SetActive(false);
        _storyMode.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        menuState = MenuState.storyMode;
	}
	
	// Update is called once per frame
	void Update () {
		if (menuState == MenuState.mainMenu)
        {
            Debug.Log("we are in main menu mode");
        }

        if (menuState == MenuState.introMode)
        {
            Debug.Log("we are in intro mode");

            _introMode.SetActive(true);
            _mainMenuMode.SetActive(false);
        }

        if (menuState == MenuState.merchantMode)
        {
            Debug.Log("we are in merchant mode");

            _merchantMode.SetActive(true);
            _player.SetActive(true);
            _introMode.SetActive(false);
            _mainMenuMode.SetActive(false);
        }

        if (menuState == MenuState.storyMode)
        {
            _merchantMode.SetActive(false);
            _player.SetActive(true);
            _introMode.SetActive(false);
            _mainMenuMode.SetActive(false);
            _storyMode.SetActive(true);
        }
    }

    public void changeState()
    {
        if (menuState == MenuState.mainMenu)
        {
            menuState = MenuState.introMode;
            Debug.Log("change state");

        }

        else if (menuState == MenuState.introMode)
        {
            menuState = MenuState.merchantMode;
        }

        else if (menuState == MenuState.merchantMode)
        {
            menuState = MenuState.storyMode;
            player.changeInventoryState(1);
        }
        
    }
}
