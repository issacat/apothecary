using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuState
{
    mainMenu,
    introMode,
    scavengeMode,
    storyMode
}

public class WorldScript : MonoBehaviour {
    public static MenuState menuState;

    public GameObject _mainMenuMode;
    public GameObject _scavengeMode;
    public GameObject _player;
    public GameObject _storyMode;

    public playerScript player;
    public customerScript customer;
    public merchantScript merchant;

    void Awake()
    {
        _mainMenuMode = GameObject.FindGameObjectWithTag("mainMenuMode");
        _scavengeMode = GameObject.FindGameObjectWithTag("scavengeMode");
        _player = GameObject.FindGameObjectWithTag("Player");
        _storyMode = GameObject.FindGameObjectWithTag("storyMode");

        _mainMenuMode.SetActive(true);
        _scavengeMode.SetActive(false);
        _player.SetActive(false);
        _storyMode.SetActive(false);

        Cursor.lockState = CursorLockMode.Confined;
    }

	// Use this for initialization
	void Start () {
        menuState = MenuState.mainMenu;
    }
	
	// Update is called once per frame
	void Update () {
		if (menuState == MenuState.mainMenu)
        {
            //Debug.Log("we are in main menu mode");
        }

        if (menuState == MenuState.scavengeMode)
        {
            //Debug.Log("we are in merchant mode");

            _scavengeMode.SetActive(true);
            _mainMenuMode.SetActive(false);
            _storyMode.SetActive(false);
        }

        if (menuState == MenuState.storyMode)
        {
            _scavengeMode.SetActive(false);
            _player.SetActive(true);
            _mainMenuMode.SetActive(false);
            _storyMode.SetActive(true);
        }
    }

    public void changeState()
    {
        if (menuState == MenuState.mainMenu)
        {
            menuState = MenuState.storyMode;
            // Debug.Log("change state");
            player.togglePlayer();
        } else if (menuState == MenuState.scavengeMode)
        {
            menuState = MenuState.storyMode;
            player.togglePlayer();
        }
        else if (menuState == MenuState.storyMode)
        {
            menuState = MenuState.scavengeMode;
            player.togglePlayer();
            player.closeEndModal();
        }

    }

    public void endDay()
    {
        player.day++;
        if (customer.charaState %2 == 0)
        {
            customer.charaState++;
            customer.setChara();
        }
    }
}
