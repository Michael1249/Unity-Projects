using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abstract_MoveSet : MonoBehaviour {
    public float TimeToLive;

    protected virtual void Update()
    {
        TimeToLive -= Time.deltaTime;
        if (TimeToLive < 0) DestroyBall();
    }
    public virtual void DestroyBall() { Destroy(this.gameObject); }
}
