using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score  {
    public int score;
    public string nombre;

    public Score(int score, string nombre)
    {
        this.score = score;
        this.nombre = nombre;
    }

    public Score()
    {
    }

    public Score(string nombre)
    {
        this.nombre = nombre;
    }

    public void setScore(int score)
    {
        this.score = score;
    }
    public void setNombre(string nombre)
    {
        this.nombre = nombre;
    }
}
