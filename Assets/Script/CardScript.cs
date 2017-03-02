using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {
	public string reqName;
	public string ingred1, ingred2, ingred3, ingred4, ingred5;
	public int deadline;
	public int rewardAmount;
	private int pos;

	private Text nameText;
	private Text rewardText;
	private Toggle req1Toggle;
	private Toggle req2Toggle;
	private Toggle req3Toggle;
	private Toggle req4Toggle;
	private Toggle req5Toggle;
	private Text deadlineText;

	// Use this for initialization
	void Start () {
		nameText = transform.FindChild ("Name field").GetComponent<Text> ();
		rewardText = transform.FindChild ("Reward field").GetComponent<Text> ();
		deadlineText = transform.FindChild ("Deadline field").GetComponent<Text> ();
		req1Toggle = transform.FindChild ("Req1").GetComponent<Toggle> ();
		req2Toggle = transform.FindChild ("Req2").GetComponent<Toggle> ();
		req3Toggle = transform.FindChild ("Req3").GetComponent<Toggle> ();
		req4Toggle = transform.FindChild ("Req4").GetComponent<Toggle> ();
		req5Toggle = transform.FindChild ("Req5").GetComponent<Toggle> ();

		req1Toggle.transform.FindChild("Label").GetComponent<Text>().text = ingred1;
		req2Toggle.transform.FindChild("Label").GetComponent<Text>().text = ingred2;
		req3Toggle.transform.FindChild("Label").GetComponent<Text>().text = ingred3;
		req4Toggle.transform.FindChild("Label").GetComponent<Text>().text = ingred4;
		req5Toggle.transform.FindChild("Label").GetComponent<Text>().text = ingred5;

		nameText.text = reqName;
		rewardText.text = rewardAmount.ToString();
		deadlineText.text = deadline.ToString();
	}

	// Update is called once per frame
	void Update () {

	}
}
