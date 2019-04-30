using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFly_AnimDead : LineFly
{
    public override void DestroyBall()
    {
        GetComponent<Animator>().Play("DestroyBall");
    }
    private void DestroyBallAnim()
    {
        Destroy(this.gameObject);
    }
}