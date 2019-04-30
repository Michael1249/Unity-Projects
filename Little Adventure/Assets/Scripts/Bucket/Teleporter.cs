using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public Vector2 Point;
    public bool Relativ;
    public HiderController HC;
    private Collider2D Other;
    public SimpleEvent OnTeleport;
    void Start()
    {
        //enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        HC.Hide(0.5f, 0.1f);
        Other = other;
        other.GetComponent<Player_Controller>().CanControl = false;
        enabled = true;
    }
    void Update()
    {
        if (HC.enabled&&HC.Timer>0.5)
        {
            Other.GetComponent<Player_Controller>().CanControl = true;
            if (Relativ)
                Other.transform.position += (Vector3)Point;
            else
                Other.transform.position = Point;
            Other = null;
            enabled = false;
            if (OnTeleport != null) OnTeleport.Invoke();
        }
    }
}
