using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scavengeScript : MonoBehaviour {
    public int actions;

    public WorldScript world;
    public ingredientScript ing;

    public GameObject[] actionPoints;

    // Use this for initialization
    void Start () {
        actions = 3;

        actionPoints = GameObject.FindGameObjectsWithTag("action");
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
    }

    public void useAction()
    {
        if(actions >= 0)
        {
            actions--;
        }
    }

    public void endScavenge()
    {
        if (actions <= 3)
        {
            world.changeState();
            world.endDay();
            actions = 3;
        }
    }

    public void scavengeArea1()
    {
        if (actions >= 0)
        {
            ing.addIngredients(1);
        }
    }

    public void scavengeArea2()
    {
        if (actions >= 0)
        {
            ing.addIngredients(2);
        }
    }
}
