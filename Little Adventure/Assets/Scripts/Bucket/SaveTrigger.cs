using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour {
    Saver _saver;
    void Start()
    {
        _saver = GameObject.FindGameObjectWithTag("Saver").GetComponent<Saver>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {if(enabled)
        if (other.gameObject.tag == "Player")
        {
            _saver.SetSave();
                enabled = false;
        }
    }
}
