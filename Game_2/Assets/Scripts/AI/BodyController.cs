using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour {
    protected Rigidbody2D _rigidBody;
    protected Animator _animator;
    [SerializeField]
    protected bool FlipX;
    [HideInInspector]
    public float Angle;
    public void SetAngle(Vector2 direction)
    {
        Angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);
    }
    public void SetAngle(float direction)
    {
        Angle = direction; 
    }
    //идти в сторону direction со скоростью speed и тормозим если идём назад или в сторону
    public virtual void Move(Vector2 direction, float speed, float angleStoping)
    {
        float delataAngle = Mathf.Abs(Mathf.DeltaAngle(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Angle));
        _rigidBody.AddForce(direction / direction.magnitude * speed * Time.deltaTime * (1 - angleStoping * delataAngle / 180));
        //_MoveState = Move_State.Move;
        //animator.Play("Walk");
    }

    public virtual void Move(float direction, float speed, float angleStoping)
    {
        float delataAngle = Mathf.Abs(Mathf.DeltaAngle(direction, Angle));
        _rigidBody.AddForce(new Vector2(Mathf.Cos(direction*Mathf.Deg2Rad), Mathf.Sin(direction * Mathf.Deg2Rad)) * speed * Time.deltaTime * (1 - angleStoping * delataAngle / 180));
        //_MoveState = Move_State.Move;
        //animator.Play("Walk");
    }

    public virtual void Dead()
    {
        if (_animator.GetBool("Right")^FlipX)
            _animator.Play("RightDead");
        else
            _animator.Play("LeftDead");
        //GetComponent<Collider2D>().enabled = false;
        //GetComponent<AbstractController>().OnDead();
        this.enabled = false;
    }
    internal void Respawn()
    {
        _animator.Play("Idle");
        GetComponent<Stats>().HP = GetComponent<Stats>()._Max_HP;
        this.enabled = true;
    }

    protected virtual void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
}
