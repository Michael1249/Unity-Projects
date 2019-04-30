using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButtonCode : MonoBehaviour {

    [SerializeField]
    Animator Gate;
    [SerializeField]
    private bool toggle = true;
    [SerializeField]
    private bool[] Code;
    private bool State;
    void Start()
    {
        Set(!Check());
    }
    public bool Check()
    {
        bool flag = true;
        foreach (bool key in Code)
        {
            if (key)
            {
                flag = false;
                break;
            }
        }
        return flag;
    }
    public void Set(int num)
    {
        if (toggle)
            Code[num] = !Code[num];
        else
            Code[num] = false;
        Set(!Check());
    }
    private void Set(bool flag)
    {
        if (flag != State)
        {
            State = flag;
            if (flag)
            {
                Gate.Play("GateOn");
            }
            else
            {
                Gate.Play("GateOff");
            }
        }
    }
}
