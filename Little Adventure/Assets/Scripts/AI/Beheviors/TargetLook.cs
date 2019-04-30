using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLook : AI_Behevior {
    [SerializeField]
    protected float LookSpeed;
    [SerializeField]
    public float AngleDelta;
    [HideInInspector]
    public List<Collider2D> Others;
    public Transform GetTarget() { return Others[0].transform; }

    protected float AngleCollisionDelta=0;
    //public bool AngleCollision
    public override void SetActivBeh(bool value)
    {
        base.SetActivBeh(value);
        if (value && _trigger != null)
        {
            Others = ((Colider_Trigger)(_trigger)).Others;
        }
    }
    protected float TargetAngle()
    {
        return Mathf.Atan2(Others[0].transform.position.y - transform.position.y,
            Others[0].transform.position.x - transform.position.x)*Mathf.Rad2Deg;
    }
    protected bool IsLookingAtTarget()
    {
        return Mathf.DeltaAngle(Body.Angle, TargetAngle()) < 5;
    }
    protected void Look()
    {
        AngleCollisionDelta *= 0.95f;
        Body.Angle += LookSpeed * Mathf.DeltaAngle(Body.Angle, TargetAngle() + AngleDelta+AngleCollisionDelta);
    }
    protected float Range()
    {
        return (Others[0].transform.position - transform.position).magnitude;
    }
    protected virtual void Update()
    {
        Look();
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if(enabled)
        if (coll.gameObject.tag == "Wall")
        {

            Vector2 V = coll.contacts[0].point - (Vector2)transform.position;
            float value = Mathf.DeltaAngle(TargetAngle()+AngleDelta, Mathf.Atan2(V.y, V.x) * Mathf.Rad2Deg);
            if(Mathf.Abs(value)<90)
            AngleCollisionDelta -= value/2;
        }
    }
}
