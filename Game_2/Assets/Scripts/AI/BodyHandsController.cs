using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHandsController : BodyController {

    public GameObject HandL;
    public GameObject HandR;
    [HideInInspector]
    public float AngleDelta=0;
    [HideInInspector]
    public float AngleDeltaForAnimator=0;
    [SerializeField]
    protected float _handsXRad=0.4f;
    [SerializeField]
    protected float _handsYRad = 0.4f;
    [SerializeField]
    protected float _handsHeight = 0.45f;
    [SerializeField]
    protected float _handsAngDelta=0.6f;

    protected override void Start()
    {
        base.Start();
        _handsXRad *= 0.2f;
        _handsYRad *= 0.2f;
        _handsHeight *= 0.2f;
    }

    public float HandsHeight
    {
        get
        {
            return _handsHeight;
        }
    }

    protected virtual void Update()
    {
        float ang = (Angle+AngleDelta+AngleDeltaForAnimator) * Mathf.Deg2Rad;
        HandL.transform.localPosition= new Vector3(_handsXRad*Mathf.Cos(ang+_handsAngDelta),
            _handsHeight+ _handsYRad * Mathf.Sin(ang + _handsAngDelta),0.02f* Mathf.Sin(ang + _handsAngDelta));
        HandR.transform.localPosition= new Vector3(_handsXRad*Mathf.Cos(ang - _handsAngDelta),
            _handsHeight+ _handsYRad * Mathf.Sin(ang - _handsAngDelta),0.02f * Mathf.Sin(ang - _handsAngDelta));
    }
}
