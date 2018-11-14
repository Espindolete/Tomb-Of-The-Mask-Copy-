using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour {
    public GameObject[] grids;  
    public GameObject ui;
    public GameObject uiPerdiste;
    public bool nuevoJuego = false;//publico por si lo quiero controlar con otro script
    public bool inputeado = false;
    public string name;
    public Score puntuacion;
    private Apier api = new Apier();
    private GameObject inputField;
    private GameObject pl;
    private Behaviour plContr;
    private int lastCheck=-1;
    private bool thisRonda = false;

    Queue<GameObject> thisGame= new Queue<GameObject>();
    
    void Start () {
        inputField = GameObject.FindGameObjectWithTag("Respawn");
        pl=GameObject.FindGameObjectWithTag("Player");
        plContr = pl.GetComponent<Movement>();
        StartCoroutine(api.Get());
        inputeado = false;
        nuevoJuego = false;
    }

	void Update () {
        if (pl.activeInHierarchy == false && thisRonda == true)
        {
            puntuacion= new Score(pl.GetComponent<Movement>().puntuacion,name);
            StartCoroutine(api.Post(puntuacion));
            thisRonda = false;
            Resetting();
        }
        else if (pl.activeInHierarchy == true && thisRonda == false)
        { //tengo q hacer cuando se resetea tambien
            thisRonda = true;
            Debug.Log("Inició otra partida");
        }
        if (plContr.isActiveAndEnabled)
        {
            CheckPos();
        }
    }

    void LateUpdate()
    {
        if (inputeado) {
            Debug.Log(inputeado);
            if (!nuevoJuego ) {

                ui.SetActive(true);
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    pl.SetActive(true);
                    plContr.enabled = true;
                    thisGame = new Queue<GameObject>();
                    uiPerdiste.SetActive(false);
                    ui.SetActive(false);
                    nuevoJuego = true;
                    inputeado = false;
                }
            }
        }
    }

    private void CheckPos()
    {//en el grid inicial el punto mas alto es en y:36  y el punto mas bajo es y:-1//esto es para referencia
        if (pl.transform.position.y > lastCheck)
        {
            lastCheck += 27;//esto tengo q cmbiar a algo distinto tipo 36+alturadelgrid*cantidaddegridsusados
            GameObject nuevoGrid = Instantiate(grids[Random.Range(0, grids.Length)], new Vector3(-0.5f, lastCheck, 0),Quaternion.identity);
            thisGame.Enqueue(nuevoGrid);
            if (thisGame.Count>3)
            {
                Destroy(thisGame.Dequeue());
            }
        }
    }

    private void Resetting()
    {
        lastCheck = -1;
        plContr.enabled = false;
        Vector3 nuevo = Vector3.zero;
        nuevo.x = 2;
        pl.transform.position = nuevo;
        uiPerdiste.SetActive(true);
        while (thisGame.Count>0)
        {
            Destroy(thisGame.Dequeue());
        }
        nuevoJuego = false;
        DeployInput();
    }

    private void DeployInput()
    {
        inputeado = false;
        inputField.gameObject.SetActive(true);
        
    }
}