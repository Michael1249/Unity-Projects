using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBuffer : MonoBehaviour {

    [SerializeField]
    private PrologMessage Target;

    public string[] Messages;
    public float[] Delays;
    public float[] AlphaDelays;
    
    public void Show(int num)
    {
        Target.Set(Messages[num], Delays[num], AlphaDelays[num]);
    }
}
