using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {

    public GameObject ui;

    private GameObject pl;
    Behaviour plContr;

    bool thisRonda = false;
	// Use this for initialization
	void Start () {
        pl=GameObject.FindGameObjectWithTag("Player");
        plContr = pl.GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
        if(pl.activeInHierarchy == false && thisRonda==true)
        {
            thisRonda = false;
            Debug.Log("se desactivo");
        }
        if(pl.activeInHierarchy == true && thisRonda == false)
        {
            thisRonda = true;
            Debug.Log("esta activado");
        }

    }
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            plContr.enabled = true;
            ui.SetActive(false);
        }
        if (pl.activeInHierarchy == true)
        {
            string puntuacion=plContr.GetComponent<string>();
        }
    }
}
