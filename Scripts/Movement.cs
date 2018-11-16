using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public float speed;
    
    Direccion direccion;

    [SerializeField] bool movingHor,canCheck;
    [SerializeField] public LayerMask obstacleMask;
    [SerializeField] public LayerMask espinasMask;
    [SerializeField] public LayerMask espinasTimedMask;
    public GameObject WOD;

    public GameObject uiPuntuacion;

    public int puntuacion = 2;

    Rigidbody2D rb;
    Rigidbody2D WallOfDeath;
    // Use this for initialization
    void Start() {
        WallOfDeath = WOD.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        WallOfDeath.velocity = Vector2.up * (speed / 15) * Time.fixedDeltaTime;
    }
    
    private void Update()
    {
        if ((int)transform.position.y > puntuacion)
        {
            puntuacion = (int)transform.position.y;
        }
        uiPuntuacion.GetComponent<Text>().text = "Puntuacion: \n " + puntuacion;
        Vector3 posicion = transform.position;
        posicion.z = -10;
        posicion.x = 3;
        posicion.y += 2;
        Camera.main.transform.position = posicion;
        if (movingHor)
        {
            switch (direccion)
            {
                case Direccion.Oeste:
                    CheckAtDir(Vector2.left);
                    break;
                case Direccion.Este:
                    CheckAtDir(Vector2.right);
                    break;
        }
        }
        else
        {
            switch (direccion)
            {
                case Direccion.Norte:
                    CheckAtDir(Vector2.up);
                    break;
                case Direccion.Sur:
                    CheckAtDir(Vector2.down);
                    break;
            }
        }

        if (canCheck)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                movingHor = true;
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direccion = Direccion.Oeste;
                }
                else if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direccion = Direccion.Este;
                }
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                movingHor = false;
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    direccion = Direccion.Sur;
                }
                else if (Input.GetAxisRaw("Vertical") > 0)
                {
                    direccion = Direccion.Norte;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        switch (direccion)
        {
            case Direccion.Norte:
                rb.velocity = Vector2.up * speed * Time.fixedDeltaTime;
                break;
            case Direccion.Sur:
                rb.velocity = Vector2.down * speed * Time.fixedDeltaTime;
                break;
            case Direccion.Este:
                rb.velocity = Vector2.right * speed * Time.fixedDeltaTime;
                break;
            case Direccion.Oeste:
                rb.velocity = Vector2.left * speed * Time.fixedDeltaTime;
                break;
        }

    }

    void Perdi(float altura)
    {
        WallOfDeath.velocity = Vector2.zero;
        puntuacion =(int)altura;
        this.gameObject.SetActive(false);
    }




    void CheckAtDir( Vector2 dir)
    {
        if (Physics2D.Raycast(transform.position, transform.TransformDirection(dir), 0.6f, obstacleMask) )
        {
            canCheck = true;
        }
        else
        {
            canCheck = false;
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(dir), 0.6f, espinasMask)) 
            {
                Perdi(transform.position.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Wall of Death")
        {
            Perdi(transform.position.y);
        }
    }
}
