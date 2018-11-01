using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate: MonoBehaviour {

    Behaviour player;
    public GameObject ui;
	// Use this for initialization
	void Start () {
        player = GetComponent<Movement>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") != 0)
        {
            player.enabled = true;
            ui.SetActive(false);
        }
	}
}
