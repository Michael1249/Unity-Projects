using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehevior : AI_Behevior
{
    public override void SetActivBeh(bool value)
    {
        this.enabled = value;
    }
    
    void Update()
    {
        Body.Angle += 1;
    }
}
