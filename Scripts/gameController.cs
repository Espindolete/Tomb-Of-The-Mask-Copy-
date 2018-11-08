using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
    public GameObject[] grids;


    
    public GameObject ui;
    public GameObject uiPerdiste;

    private Apier api = new Apier();
    private GameObject pl;
    private Behaviour plContr;
    private Score puntuacion;
    private int lastCheck=0;
    private bool thisRonda = false;
    private bool nuevoJuego = true;


    Queue<GameObject> thisGame= new Queue<GameObject>();
    // Use this for initialization
    void Start () {
        pl=GameObject.FindGameObjectWithTag("Player");
        plContr = pl.GetComponent<Movement>();
        StartCoroutine(api.Get());        
	}

	void Update () {
        if (pl.activeInHierarchy == false && thisRonda == true)
        {
            puntuacion = pl.GetComponent<Movement>().score;
            StartCoroutine(api.Post(puntuacion));
            thisRonda = false;
            Resetting();
        }
        else if (pl.activeInHierarchy == true && thisRonda == false)
        { //tengo q hacer cuando se resetea tambien
            thisRonda = true;
            Debug.Log("Inició otra partida");
        }
        CheckPos();
    }
    void FixedUpdate()
    {
        if (nuevoJuego) {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                plContr.enabled = true;
                thisGame = new Queue<GameObject>();
                uiPerdiste.SetActive(false);
                ui.SetActive(false);
                nuevoJuego = false;
            }
        }

    }

    private void CheckPos()
    {//en el grid inicial el punto mas alto es en y:36  y el punto mas bajo es y:-1
        
        if (pl.transform.position.y > lastCheck)
        {
            lastCheck += 27;
            GameObject nuevoGrid = Instantiate(grids[Random.Range(0, grids.Length)], new Vector3(-0.5f, lastCheck, 0),Quaternion.identity);
            thisGame.Enqueue(nuevoGrid);
            Debug.Log(thisGame.Count);
            if (thisGame.Count>3)
            {
                Destroy(thisGame.Dequeue());
            }

        }
    }

    private void Resetting()
    {
        lastCheck = 27;
        plContr.enabled = false;
        Vector3 nuevo = Vector3.zero;
        nuevo.x = 2;
        pl.transform.position = nuevo;
        
        uiPerdiste.SetActive(true);
        while (thisGame.Count !=0)
        {
            Destroy(thisGame.Dequeue());
        }
        nuevoJuego = true;
    }
}
