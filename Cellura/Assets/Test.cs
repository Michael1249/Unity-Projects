using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Threading;
public class Test : MonoBehaviour {
    private Compaund compaund;
    private MeshRenderer mesh;
    public Gradient gradient;
    // Use this for initialization
    
	void Start () {
       // Thread t = new Thread(new ThreadStart(compaund.Request));
       // t.Start();
        compaund = new Compaund("http://192.168.0.111/");
        mesh = GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        mesh.material.color =gradient.Evaluate(compaund.Request("").ReadInt16() / 1024.0f);
    }
}

public class Compaund
{
    private string URI;
    private BinaryReader reder; public BinaryReader DATA { get { return reder; } }
    public Compaund(string uRI)
    {
        URI = uRI;
    }
    public  void Request(string data)
    {
        try
        {
            HttpWebRequest request = WebRequest.Create(URI + data) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (reder != null) reder.Close();
            reder = new BinaryReader(response.GetResponseStream());
            reder.ReadBytes(23);
        }
        catch
        {
            reder = null;
        }
    }
}

