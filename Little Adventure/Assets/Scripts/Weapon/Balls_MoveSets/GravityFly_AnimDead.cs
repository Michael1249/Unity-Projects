using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFly_AnimDead : Abstract_MoveSet {
    public float StartSpeed;
    public float GravityScale=100;
    [HideInInspector]
    public Vector2 dir;
    private Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.AddForce(transform.up * StartSpeed);
        dir *= GravityScale;
    }
    protected override void Update()
    {
        base.Update();
        RB.AddForce(dir*Time.deltaTime);
    }
    public override void DestroyBall()
    {
        GetComponent<Animator>().Play("DestroyBall");
    }
    private void DestroyBallAnim()
    {
        Destroy(this.gameObject);
    }
}
