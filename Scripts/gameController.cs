using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {

    public GameObject ui;
    Apier api = new Apier();
    private GameObject pl;
    Behaviour plContr;
    Score puntuacion;

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
            puntuacion = pl.GetComponent<Movement>().score;
            StartCoroutine(api.Post(puntuacion));
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
        if (thisRonda == true) { 
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                plContr.enabled = true;
                ui.SetActive(false);
            }
        }
    }
}
