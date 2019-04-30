using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Controller : Abstract_MoveSet {

    public AudioSource sound;
    public float minScale = 1;
    public float maxScale = 1;
    void Start () {
        sound.pitch = Random.Range(minScale, maxScale);
	}
}
