using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    public int ColorTime=1000;
    private MeshRenderer render;
    private Rools rools;
    private GameObject Life;
    private int Iteration = 0;
    //[SerializeField]
    private int Members = -1;
    public bool State=false;
	void Awake () {
        render = GetComponentInChildren<MeshRenderer>();
        Life = transform.GetChild(0).gameObject;
        rools = transform.parent.GetComponent<Rools>();
        Set(State);
    }
    void OnTriggerEnter()
    {
            Members++;
        enabled = true;
    }
    void OnTriggerExit()
    {
            Members--;
        enabled = true;
    }
	// Update is called once per frame
	void Update () {
        Check();
        Iteration++;
        //Debug.Log((float)(Iteration) / ColorTime);
        render.material.color = rools.gradient.Evaluate((float)(Iteration) / ColorTime);
	}
    public void Set(bool flag)
    {
        enabled = flag;
        render.enabled = flag;
        Life.transform.localScale = flag ? new Vector3(1.1f, 1.1f, 1.1f) : new Vector3(0.1f, 0.1f, 0.1f);
        State = flag;
    }
    void Check()
    {
        if (State)
        {
            if (!rools.Roole_Stay[Members])
            {
                Set(false);
            }
        }
        else
        {
            if (rools.Roole_Born[Members])
            {
                Set(true);
                Iteration = 0;
            }
        }
    }
}
