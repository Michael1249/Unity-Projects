using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
    }
}
