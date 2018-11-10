using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Puntos : MonoBehaviour {

    Tilemap tilemap;
	// Use this for initialization
	void Start () {
        tilemap=GetComponent<Tilemap>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //nose

    }
}
