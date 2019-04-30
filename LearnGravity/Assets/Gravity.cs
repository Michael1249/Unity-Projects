using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    public double G=10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Rigidbody2D[] Bodyes= this.GetComponentsInChildren<Rigidbody2D>();
        Vector2 ForseV;
        float ForseM;
        for (int i = 0; i < Bodyes.Length-1; i++)
        {
            for(int j = i + 1; j < Bodyes.Length; j++)
            {
                ForseV = Bodyes[j].transform.position - Bodyes[i].transform.position;
                ForseM = (float)G/ForseV.SqrMagnitude();
                ForseV.Normalize();
                Bodyes[i].AddForce(ForseV*ForseM* Bodyes[j].mass);
                Bodyes[j].AddForce(-ForseV*ForseM* Bodyes[i].mass);
            }
        }
	}
}
