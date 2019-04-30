using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Клас инкапсулирющий управление, анимации и состояния подконтрольного обьекта
(игрока) 
*/
public class Player_Body : Human_Body {
    
    

    //повернуться в сторону мыши
    public void LookAtMouse()
    {
        SetAngle(PlayerToMouse());
    }

    //ускорение в направлении миши
    public void Dash(float speed)
    {
        //Vector2 direction = PlayerToMouse();
        float ang = Angle*Mathf.Deg2Rad;
        //rigidBody.AddForce(direction / direction.magnitude * speed * Time.deltaTime);
        _rigidBody.AddForce(new Vector2(Mathf.Cos(ang), Mathf.Sin(ang)) * speed * Time.deltaTime);
        _MoveState = Human_Body.Move_State.Dash;
        _animator.SetBool("Move", false);
        _animator.Play("Dash");
    }

    //вектор от игрока к курсору
    public Vector2 PlayerToMouse()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position+Vector3.down*_handsHeight;
        //return Camera.main.ScreenPointToRay(Input.mousePosition).direction;
    }
    


}
