using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum MenuState
{
    mainMenu,
    introMode,
    scavengeMode,
    storyMode
}

public class WorldScript : MonoBehaviour {
    public static MenuState menuState;

    public bool newGame; 

    public GameObject _mainMenuMode;
    public GameObject _scavengeMode;
    public GameObject _player;
    public GameObject _storyMode;

    public GameObject _transitionScreen;
    public GameObject _continueButton;

    public GameObject _endScreen;

    public playerScript player;
    public customerScript customer;

    public AudioSource music;
    public AudioSource door;

    void Awake()
    {
        _mainMenuMode = GameObject.FindGameObjectWithTag("mainMenuMode");
        _scavengeMode = GameObject.FindGameObjectWithTag("scavengeMode");
        _player = GameObject.FindGameObjectWithTag("Player");
        _storyMode = GameObject.FindGameObjectWithTag("storyMode");

        _transitionScreen = GameObject.Find("transitionScreen");
        _transitionScreen.SetActive(false);

        _continueButton = GameObject.Find("continue button");

        _endScreen = GameObject.Find("endScreen");
        _endScreen.SetActive(false);

        _mainMenuMode.SetActive(true);
        _scavengeMode.SetActive(true);
        _player.SetActive(true);
        _storyMode.SetActive(true);

        Cursor.lockState = CursorLockMode.Confined;

        music = GameObject.Find("Music").GetComponent<AudioSource>();
        door = GameObject.Find("doorSound").GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {
        menuState = MenuState.mainMenu;
        music.Play();
        newGame = true;
    }
	
	// Update is called once per frame
	void Update () {
		if (menuState == MenuState.mainMenu)
        {
            //Debug.Log("we are in main menu mode");
            _mainMenuMode.SetActive(true);
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
            _player.SetActive(true);
            _mainMenuMode.SetActive(false);
            _storyMode.SetActive(true);
            _scavengeMode.SetActive(false);
        }
    }

    public void changeState()
    {
        if (menuState == MenuState.mainMenu)
        {
            menuState = MenuState.storyMode;
            StartCoroutine(transitionScreen());
            music.clip = Resources.Load<AudioClip>("Louie Zong - Dive - 02 Sunlit Shallows");
            music.Play();
            player.toggleBook();
            player.toggleBook();
            customer.setChara();
            customer.enter.Play();
            // Debug.Log("change state");
        } else if (menuState == MenuState.scavengeMode)
        {
            StartCoroutine(transitionScreen());
            menuState = MenuState.storyMode;
            player.togglePlayer();
            player.toggleItem();
            music.clip = Resources.Load<AudioClip>("Louie Zong - Dive - 02 Sunlit Shallows");
            music.Play();
            door.Play();

        }
        else if (menuState == MenuState.storyMode)
        {
            StartCoroutine(transitionScreen());
            menuState = MenuState.scavengeMode;
            player.togglePlayer();
            player.closeEndModal();
            music.clip = Resources.Load<AudioClip>("Louie Zong - Sun - 02 The Glen");
            music.Play();
            door.Play();
        }

    }

    public void mainMenu()
    {
        StartCoroutine(transitionScreen());
        menuState = MenuState.mainMenu;
        _continueButton.GetComponent<Button>().interactable = true;
        newGame = false;

        music.clip = Resources.Load<AudioClip>("Louie Zong - Walk - 04 The Way Back");
        music.Play();
    }

    public void restartGame()
    {
        if (!newGame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void endGame()
    {
        StartCoroutine(transitionScreen());
        newGame = false;
        if (player.gratitude <= 17)
        {
            _endScreen.SetActive(true);
            _endScreen.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("ending_scene_3");
        }
        else if (player.gratitude > 17 && player.gratitude <= 26)
        {
            _endScreen.SetActive(true);
            _endScreen.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("ending_scene_1");

        }
        else if (player.gratitude > 26)
        {
            _endScreen.SetActive(true);
            _endScreen.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("ending_scene_2");
        }
        music.clip = Resources.Load<AudioClip>("Louie Zong - Sun - 04 Beneath The Oak");
        music.Play();
    }

    private IEnumerator transitionScreen()
    {
        _transitionScreen.SetActive(true);
        _transitionScreen.GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.05F);

        for (float i = 1; i >= 0; i -= Time.deltaTime * 5)
        {
            // set color with i as alpha
            _transitionScreen.GetComponentInChildren<Image>().color = new Color(1, 1, 1, i);
            yield return null;
        }
        _transitionScreen.SetActive(false);
    }
}
