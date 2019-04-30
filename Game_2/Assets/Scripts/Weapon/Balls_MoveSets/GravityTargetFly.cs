using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTargetFly :  GravityFly_AnimDead{
    [HideInInspector]
	public Transform target;
	protected override void Update () {
        if(target!=null)
            
                dir = ((Vector2)target.position - (Vector2)transform.position).normalized*GravityScale;
            
        base.Update();
	}
}
