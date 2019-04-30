using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : RandomLook
{
    public float SpeedScaller;
    public float StayTime;
    public float StayTimeDelta;
    public float MoveTime;
    public float MoveTimeDelta;
    private float _time=0;
    private bool Move=true;

    public override void SetActivBeh(bool value)
    {
        base.SetActivBeh(value);
        Move = true;
        _time = 0;
    }

    protected override void Update()
    {
        if (_time <= 0)
        {
            if (Move)
            {
                _time = StayTime + Random.Range(-StayTimeDelta, StayTimeDelta);
            }
            else
            {
                _time = MoveTime + Random.Range(-MoveTimeDelta, MoveTimeDelta);
            }
            Move = !Move;
        }
        if (Move&&LookAtTarget()) Body.Move(Body.Angle, Owner._stats._Speed * SpeedScaller, 0);
        else base.Update();
        _time -= Time.deltaTime;
    }
}
