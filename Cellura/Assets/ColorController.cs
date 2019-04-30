using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {
    private float _iteration = 0;
    private MeshRenderer mesh;
    private Rools rools;

    public float Iteration1
    {
        get
        {
            return _iteration;
        }
    }

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        rools = transform.parent.GetComponent<Rools>();
        enabled = false;
    }
	void Update () {
        _iteration += 1;
        mesh.material.color = rools.gradient.Evaluate((float)(_iteration) / rools.DescreteColour);
    }
    public void Set(bool flag)
    {
        if (flag)
        {
            _iteration = 0;
            
            mesh.material.color = rools.gradient.Evaluate(0);
            enabled = true;
            mesh.enabled = true;
        }
        else
        {
            enabled = false;
            mesh.enabled = false;
        }
    }
}
