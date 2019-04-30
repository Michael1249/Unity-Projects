using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI_Behevior:MonoBehaviour{
    public Basic_Trigger _trigger;
    protected AI_Controller Owner;
    protected BodyController Body;
    public bool isTriggered()
    {
        return _trigger.Active;
    }
    

    protected virtual void Awake()
    {
        Owner = this.GetComponent<AI_Controller>();
        Body = this.GetComponent<BodyController>();
        enabled = false;
    }

    public virtual void SetActivBeh(bool value)
    {
        if(Owner.enabled)
        this.enabled = value;
    }

}
