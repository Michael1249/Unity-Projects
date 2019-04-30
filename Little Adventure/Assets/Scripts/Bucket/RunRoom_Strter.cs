using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunRoom_Strter : MonoBehaviour {

    void Start()
    {
        //Debug.Log(transform.childCount);
        for(int i=0;i<transform.childCount-1;i++)
        {
            for(int j = i + 1; j < transform.childCount; j++)
            {
                //Debug.Log("i=" + i + "  j=" + j);
                Vector2 Delta = transform.GetChild(i).position - transform.GetChild(j).position;
                if (Delta.magnitude == 1)
                {
                    transform.GetChild(i).GetComponent<Igla_Cascade>().Add(transform.GetChild(j).GetComponent<Igla_Cascade>());
                    transform.GetChild(j).GetComponent<Igla_Cascade>().Add(transform.GetChild(i).GetComponent<Igla_Cascade>());
                }
            }
        }
    }
    public void Reset()
    {
        foreach(Igla_Cascade IC in GetComponentsInChildren<Igla_Cascade>())
        {
            IC.Reset();
        }
    }
    public void Stop()
    {
        foreach (Igla_Cascade IC in GetComponentsInChildren<Igla_Cascade>())
        {
            IC.Used = true;
        }
    }
}
