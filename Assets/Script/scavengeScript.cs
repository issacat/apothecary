using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class scavengeScript : MonoBehaviour {
    public int actions;

    public WorldScript world;
    public ingredientScript ing;

    public GameObject[] actionPoints;
    public GameObject[] areas;

    public bookScript book;

    public bool act;

    public AudioSource rustle;

    // Use this for initialization
    void Start () {
        actions = 3;
        act = true;

        actionPoints = GameObject.FindGameObjectsWithTag("action");
        areas = GameObject.FindGameObjectsWithTag("area").OrderBy(go => go.name).ToArray();

        book = GameObject.Find("Book").GetComponent<bookScript>();

        rustle = GameObject.Find("scavengeSound").GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
        for (int i = 0; i < actionPoints.Length; i++)
        {
            actionPoints[i].SetActive(false);
        }
        for (int i = 0; i < actions; i++)
        {
            actionPoints[i].SetActive(true);
        }

        for (int i = 0; i <= book.maxPlaces; i++)
        {
            areas[i].GetComponentInChildren<Button>().interactable = true;
        }
    }

    public void useAction()
    {
        if(actions >= 0 && act)
        {
            actions--;
        }
    }

    public void endScavenge()
    {
        if (actions <= 3 && act)
        {
            world.changeState();
            actions = 3;
        }
    }

    public void scavengeArea1()
    {
        if (actions >= 0 && act)
        {
            // torched + ethereal
            rustle.Play();
            ing.addIngredients(1);
        }
    }

    public void scavengeArea2()
    {
        if (actions >= 0 && act)
        {
            rustle.Play();
            // blooming + dwarf
            ing.addIngredients(2);
        }
    }
    public void scavengeArea3()
    {
        if (actions >= 0 && act)
        {
            rustle.Play();
            // bog + violet
            ing.addIngredients(3);
        }
    }
    public void scavengeArea4()
    {
        if (actions >= 0 && act)
        {
            rustle.Play();
            // divine + midnight
            ing.addIngredients(4);
        }
    }
    public void scavengeArea5()
    {
        if (actions >= 0 && act)
        {
            rustle.Play();
            // tormented + midnight
            ing.addIngredients(5);
        }
    }

    public void Fade()
    {
        StartCoroutine(ActivationRoutine());
    }

    public IEnumerator ActivationRoutine()
    {
        act = false;
        for (float i = 0; i <= 1; i += Time.deltaTime*5)
        {
            // set color with i as alpha
            ing.modal.GetComponentInChildren<Image>().color = new Color(1, 1, 1, i);
            ing.modal.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, i);
            yield return null;
        }

        yield return new WaitForSeconds(0.5F);

        for (float i = 1; i >= 0; i -= Time.deltaTime*5)
        {
            // set color with i as alpha
            ing.modal.GetComponentInChildren<Image>().color = new Color(1, 1, 1, i);
            ing.modal.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, i);
            yield return null;
        }
        ing.modal.SetActive(false);
        act = true;
    }
}
