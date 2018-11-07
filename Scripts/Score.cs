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
    
    public void SetScore(int score)
    {
        this.score = score;
    }
    public void SetNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public string MakeForm()
    {
        string form = "{";
        form += @"""id"":"""",";//"id":"" ,//lo hace automatico la BD
        form += @"""nombre"":""" + this.nombre + @""",";//"Nombre" : "{{nombre}}",
        form += @"""puntuacion"":""" + this.score + @"""";//"Puntuacion" : "{{score}}"
        form += "}";
        return form;
    }
}
