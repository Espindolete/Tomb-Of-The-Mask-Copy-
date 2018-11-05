using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour {

    public float speed;
    Rigidbody2D rb;
    Direccion direccion;

    [SerializeField] bool movingHor,canCheck;
    [SerializeField] public LayerMask obstacleMask;
    [SerializeField] public LayerMask espinasMask;
    [SerializeField] public LayerMask espinasTimedMask;
    

    string nombre = "agustin";
    int puntuacion = 2;
    

    public Score score;
    
    // Use this for initialization
    void Start() {
        score = new Score(puntuacion, nombre);
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Camera.main.transform.position = transform.position;
        
        if (movingHor)
        {
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right),0.6f,obstacleMask) ||Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left),0.6f,obstacleMask))
            {
                canCheck = true;
            }
            else
            {
                canCheck = false;
                if(Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.6f, espinasMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 0.6f, espinasMask))
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 0.6f, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection( Vector2.down), 0.6f, obstacleMask))
            {
                canCheck = true;
            }
            else
            {
                canCheck = false;
                if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 0.6f, espinasMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 0.6f, espinasMask))
                {
                    this.gameObject.SetActive(false);
                }
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

    void nothing()
    {
        Debug.Log("nada");
    }
}
