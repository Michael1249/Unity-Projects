using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLook : AI_Behevior
{
    public float LookSpeed;
    public float LookTime;
    public float LookTimeDelta;
    private float _look_time=0;
    private float targetAngle;
    protected bool LookAtTarget()
    {
        return Mathf.DeltaAngle(Body.Angle, targetAngle) < 5;
    }
    protected virtual void Update()
    {
        if (_look_time <= 0)
        {
            _look_time = LookTime + Random.Range(-LookTimeDelta, LookTimeDelta);
            targetAngle = Random.Range(0, 359);
        }
        Body.Angle +=LookSpeed*Mathf.DeltaAngle(Body.Angle, targetAngle);
        _look_time -= Time.deltaTime;
       
    }
}
