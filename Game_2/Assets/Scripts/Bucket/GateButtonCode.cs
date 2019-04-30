using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButtonCode : MonoBehaviour {

    [SerializeField]
    Animator Gate;
    [SerializeField]
    private bool[] Code;
    private bool State;
    void Start()
    {
        Set(true);
    }
    public void Set(int num)
    {
        Code[num] = !Code[num];
        bool flag = true;
        foreach(bool key in Code)
        {
            if (key)
            {
                flag = false;
                break;
            }
        }
        Set(!flag);
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
