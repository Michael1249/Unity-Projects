using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Basic_Trigger : MonoBehaviour {
    protected bool _active;
    protected bool triggerEnable = true;
    public bool Active
    {
        get
        {
            return _active;
        }
    }

    public virtual bool TriggerEnable
    {
        get
        {
            return triggerEnable;
        }

        set
        {
            triggerEnable = value;
        }
    }
}
