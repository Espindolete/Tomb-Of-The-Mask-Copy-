using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Apier  {

    private string url = "http://localhost/ejemploapiphp/api.php/juego";
	// Use this for initialization
	
	
    public IEnumerator Post(string nombre,int score)
    {
        //el unityWebRequest.Post no me anda para hacer el post, tengo que hacer toda esta warangada
        var request = new UnityWebRequest(url, "POST");
        string form2 = "{";
        form2 += @"""id"":"""",";//"id":"" ,//lo hace automatico la BD
        form2 += @"""nombre"":""" + nombre + @""",";//"Nombre" : "{{nombre}}",
        form2 += @"""puntuacion"":""" + score+@"""";//"Puntuacion" : "{{score}}"
        form2 += "}";
        byte[] bodyRaw = Encoding.UTF8.GetBytes(form2);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.Send();
        Debug.Log("Status Code: " + request.responseCode);
        Debug.Log(form2);
    }

    public IEnumerator Post(Score xd)
    {
        //el unityWebRequest.Post no me anda para hacer el post, tengo que hacer toda esta warangada
        var request = new UnityWebRequest(url, "POST");
        string form2 = xd.MakeForm();
        byte[] bodyRaw = Encoding.UTF8.GetBytes(form2);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.Send();
        Debug.Log("Status Code: " + request.responseCode);
        Debug.Log(form2);
    }

    public IEnumerator Get()
    {
        using(UnityWebRequest www= UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.error != null)
            {
                Debug.Log(www.responseCode);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator Get(int xd)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url+"/"+xd))
        {
            yield return www.SendWebRequest();
            if (www.error != null)
            {
                Debug.Log(www.responseCode);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
