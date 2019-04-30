using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologMessage : MonoBehaviour {

    private float AlphaDelay;
    private float time=0;
    private float Showtime;
    private UnityEngine.UI.Text _UI;
    private TextMesh _Mesh;
    void Awake()
    {
        _UI = GetComponent<UnityEngine.UI.Text>();
        _Mesh = GetComponent<TextMesh>();
    }
    public void Set(string mesage, float time,float Alpha)
    {
        if (_UI != null) _UI.text = mesage;
        if (_Mesh != null)_Mesh.text = mesage;
        this.time = time;
        Showtime = time;
        AlphaDelay = Alpha;
    }
    void Update()
    {
        Color C;
        if (time > 0)
        {
            time -= Time.deltaTime;
            C= new Color(1, 1, 1, Mathf.Min(Mathf.Min(time, Showtime - time) / AlphaDelay, 1));
        }
        else
        {
            C= new Color(1, 1, 1, 0);
            time = 0;
        }
        if (_UI != null) _UI.color = C;
        if (_Mesh != null) _Mesh.color =C;

    }
}
