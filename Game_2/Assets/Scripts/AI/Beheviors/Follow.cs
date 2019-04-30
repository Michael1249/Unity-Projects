using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : TargetMove {
    [SerializeField]
    private float StopRange;
    public SimpleEvent OnCrossing;
    private bool inRange=false;
    protected float getRange()
    {
        return ((Vector2)(Others[0].transform.position - transform.position)).magnitude;
    }
    protected bool goToTarget()
    {
        Look();
        if (getRange() > StopRange)
        {
            Move();
            inRange = false;
            return true;
        }
        if (OnCrossing != null&&!inRange) OnCrossing.Invoke();
        inRange = true;
        return false;
    }
	protected override void Update () {
        goToTarget();
	}
}
