using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : Stats
{
    public float _DashSpeed = 60000;
    [SerializeField]
    [HideInInspector]
    private float _Mana = 100;
    public float _Max_Mana = 100;
    public float _ManaUpSpeed = 0;
    private float _Stamina = 100;
    public float _Max_Stamina = 100;
    public float _StaminaUpSpeed = 100;
    public float _DashDamagScaller = 2;
    public override float getPhisicalDamag()
    {
        if(Stamina!=_Max_Stamina)
          return _Forse / 10 * (_Lvl / 10 + 1)*_DashDamagScaller;
        return _Forse / 10 * (_Lvl / 10 + 1);
    }
    public float Mana
    {
        get
        {
            return _Mana;
        }

        set
        {
            if (value <= 0) _Mana = 0;
            else if (value > _Max_Mana) _Mana = _Max_Mana;
            else _Mana = value;
        }
    }

    public float Stamina
    {
        get
        {
            return _Stamina;
        }

        set
        {
            if (value > _Max_Stamina) _Stamina = _Max_Stamina;
            else _Stamina = value;
        }
    }

    public override void UpdateStats()
    {
        if (Stamina < _Max_Stamina)
        {
            Stamina += _StaminaUpSpeed * Time.deltaTime;
            if (Stamina > _Max_Stamina)
            {
                Stamina = _Max_Stamina;
            }
        }
        if (Mana < _Max_Mana)
        {
            Mana += _ManaUpSpeed * Time.deltaTime;
            if (Mana > _Max_Mana)
            {
                Mana = _Max_Mana;
            }
        }
    }
}
