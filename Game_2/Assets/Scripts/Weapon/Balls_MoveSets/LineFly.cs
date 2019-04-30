using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFly : Abstract_MoveSet {

    public float Speed;


    protected override void Update () {
        transform.position += transform.up*Time.deltaTime*Speed;
        base.Update();
	}
    //protected virtual 
}
