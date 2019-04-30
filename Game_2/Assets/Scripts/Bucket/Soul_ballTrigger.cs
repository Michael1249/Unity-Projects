using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul_ballTrigger : MonoBehaviour {

    public GameObject Soul;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player") { 
            other.GetComponent<Inventory>().Put(Instantiate(Soul,other.transform));
            Destroy(transform.parent.gameObject);
        }
        else
        if(other.tag == "Warior") Destroy(transform.parent.gameObject);
    }
}
