using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : TargetLook {

    public float SpeedScaller;
    public float MoveAngle;

    protected void Move()
    {
        Body.Move(TargetAngle() + MoveAngle+AngleCollisionDelta, Owner._stats._Speed * SpeedScaller, Owner._stats._AngleStoping);
    }
    protected override void Update()
    {
        Look();
        Move();
    }

}
