
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Operation : MonoBehaviour {
    private List<object> Inputs;
    private List<object> Data;
    private List<DataBufferEndSend> Outputs;
    public abstract void Calculate();
    public void Sand()
    {
        foreach(DataBufferEndSend d in Outputs)
        {
            d.Sand();
        }
    }
    struct DataBufferEndSend
    {
        public object Data;
        public List<object> Transitions;
        public void Sand()
        {
           for(int i = 0; i < Transitions.Count; i++)
            {
                Transitions[i] = Data;
            }
        }
    }
}
