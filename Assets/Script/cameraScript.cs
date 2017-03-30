using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
    public float speed = 20.0f;
    public WorldScript wrld;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            if (Input.mousePosition.x > Screen.width - (Screen.width * 0.9) && Input.mousePosition.y < Screen.height - 75 && transform.position.x < 6)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
            if (Input.mousePosition.x < Screen.width * 0.9 && Input.mousePosition.y < Screen.height - 75 && transform.position.x > -5.5)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
    }
}
