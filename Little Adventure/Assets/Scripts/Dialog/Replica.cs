using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replica:MonoBehaviour {
    public int ReplicaTag=0;
    [SerializeField]
    private Replica[] next;
    [SerializeField]
    private string[] message;
    [SerializeField]
    private Speaker _speaker;
    public bool ReplicaActive = true;
    public bool ShowOnce = false;
    [SerializeField]
    private bool lastReplica;
    public SimpleEvent OnStartEvent;
    public SimpleEvent OnEndEvent;
    public Replica[] Next
    {
        get
        {
            return next;
        }
    }
    public Speaker _Speaker
    {
        get
        {
            return _speaker;
        }
    }
    public bool LastReplica
    {
        get
        {
            return lastReplica;
        }
    }
    public string[] Message
    {
        get
        {
            return message;
        }
    }

    public enum Speaker 
    {
        Other,
        Player
    }
}
