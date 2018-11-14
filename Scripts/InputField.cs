using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour {
    public GameObject go;
    public Text txt;

    private void Start()
    {
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.Return)){
            go.GetComponent<gameController>().name = txt.text;
            gameController gcc=go.GetComponent<gameController>();
            gcc.name = txt.text;
            gcc.inputeado = true;
            this.gameObject.SetActive(false);
        }
    }
}
