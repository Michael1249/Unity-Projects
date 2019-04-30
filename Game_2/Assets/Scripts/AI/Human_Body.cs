using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Body : BodyHandsController
{
    //владелец
    public AbstractController controller;
    //состояния движения (стоять, идти...)
    [HideInInspector]
    public Move_State _MoveState;
    private AudioSource Sound;
    private SpriteRenderer Sprite;
    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        controller = GetComponent<AbstractController>();
        Sound = GetComponent<AudioSource>();
        Sprite = GetComponentInChildren<SpriteRenderer>();
    }
    public void TipTop()
    {

        if (Sound != null) Sound.Play();
    }
    public override void Move(Vector2 direction, float speed, float angleStoping)
    {
        base.Move(direction, speed, angleStoping);
        _MoveState = Move_State.Move;
        _animator.SetBool("Right", direction.x > 0);
        _animator.SetBool("Move", true);
    }

    public override void Move(float direction, float speed, float angleStoping)
    {
        base.Move(direction, speed, angleStoping);
        _MoveState = Move_State.Move;
        _animator.SetBool("Right", direction > 0 && direction < 180);
        _animator.SetBool("Move", true);
    }
    public enum Move_State
    {
        Stay,
        Move,
        Dash
    }
    

    protected override void Update()
    {
        base.Update();
        Sprite.flipX =Mathf.Cos(Angle * Mathf.Deg2Rad) < 0^FlipX;
        //проверка на переход в состояние Stay
        if (_MoveState != Move_State.Stay)
            if (_rigidBody.velocity.magnitude < 0.5 && _MoveState != Move_State.Dash)
            {
                _MoveState = Move_State.Stay;
                _animator.SetBool("Move", false);
            }
    }
}

