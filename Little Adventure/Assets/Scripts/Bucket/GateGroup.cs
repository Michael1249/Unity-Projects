using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateGroup : MonoBehaviour {

    [SerializeField]
    private Animator[] Gates;
    [SerializeField]
    private bool State=false;
    void Start()
    {
        Set(State);
    }
    public void Set(bool flag)
    {
        State = flag;
        if(flag)
            foreach(Animator Anim in Gates)
            {
                Anim.Play("GateOn");
            }
        else
            foreach (Animator Anim in Gates)
            {
                Anim.Play("GateOff");
            }

    }
    public void ReSet()
    {
        Set(!State);
    }
}
