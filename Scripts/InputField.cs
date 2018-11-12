using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour {
    public GameObject gc;
    public Text txt;
    gameController xd;
    private void Start()
    {
        xd=gc.GetComponent<gameController>();
    }

    private void Update()
    {
        Debug.Log(xd.gameObject.name);
        if (Input.GetKey(KeyCode.Return)){ 
            xd.puntuacion.SetNombre(txt.text);
            this.gameObject.SetActive(false);
        }
    }
}
