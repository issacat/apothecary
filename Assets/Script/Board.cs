using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	//private List<GameObject> requests;
	public GameObject requestPrefab;
	private CardScript cardscript;
	public Transform pos1;
	public int grea;

	// Use this for initialization
	void Start () {
		newRequest (100, "Philberto", 2, 100, "Mandrake", "Garlic", "Ginger", "Thistle", "Chocolate");
		newRequest (300, "Johnny", 1, 250, "Mandrake", "Water", "none", "none", "none");
		newRequest (500, "Ashley", 2, 100, "Wine", "Garlic", "Ginger", "Blood", "none");
		newRequest (700, "Issaca", 1, 250, "Raisins", "Water", "none", "none", "none");
		newRequest (900, "Rob", 1, 250, "Ginger", "Juice", "none", "none", "none");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Use "none" in the ingredient list (i3,i4...) to indicate no ingredient
	private GameObject newRequest(int pos, string name, int deadline, int reward, string i1, string i2, string i3, string i4, string i5) {
		GameObject req;
		req = Instantiate (requestPrefab, new Vector3(pos,50f,0f), Quaternion.identity) as GameObject;
		cardscript = req.GetComponent<CardScript> ();

		cardscript.reqName = name;
		cardscript.deadline = deadline;
		cardscript.rewardAmount = reward;
		if (i1 != "none") cardscript.ingred1 = i1;
		if (i2 != "none") cardscript.ingred2 = i2;
		if (i3 != "none") cardscript.ingred3 = i3;
		if (i4 != "none") cardscript.ingred4 = i4;
		if (i5 != "none") cardscript.ingred5 = i5;
		req.transform.SetParent (GameObject.FindGameObjectWithTag ("requestBoard").transform, false);

		return req;
	}
}
