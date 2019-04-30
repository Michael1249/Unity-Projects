using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme_Controller : MonoBehaviour {

    AudioSource AS;
    public float StartTime;
    public float EndTime;
    public float volumeScaller=1;
    public bool VolumeTarget=false;
    float time=0;
    bool flag;
	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
        enabled = false;
        if (AS.playOnAwake) StartPlay();
	}
	
	void Update () {
        time += Time.deltaTime;
        if(flag)
        {
            AS.volume = time / StartTime*volumeScaller;
            if (time > StartTime) { enabled = false; AS.volume = volumeScaller; }
        }
        else
        {
            AS.volume = (1-time / EndTime)*volumeScaller;
            if (time > EndTime)
            {
                AS.Stop();
                enabled = false;
            }
        }
	}
    public void StartPlay()
    {
        if (VolumeTarget)
        {
            time = AS.volume * StartTime;
        }
        else
        time = 0;
        flag = true;
        enabled = true;
        AS.Play();
    }
    public void EndPlay()
    {
        if (VolumeTarget)
        {
            time = (1-AS.volume) * EndTime;
        }
        else
        time = 0;
        flag = false;
        enabled = true;
    }
}
