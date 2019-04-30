using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndAtack : Follow
{

    [SerializeField]
    public HandsUse UseHand;
    [SerializeField]
    protected HitTactic HitWay;
    [SerializeField]
    protected float HitCoolDowntime;
    [SerializeField]
    protected float CoolDowntimeDelta;
    protected bool NextHand;
    protected float _time;
    public override void SetActivBeh(bool value)
    {
        base.SetActivBeh(value);
        if (value)
            Owner.weapon_controller.WeaponOn();
        else
            Owner.weapon_controller.WeaponOff();
    }

    protected void Atack()
    {
        if (_time <= 0)
        {
            _time = HitCoolDowntime + Random.Range(-CoolDowntimeDelta, CoolDowntimeDelta);
            if (UseHand == HandsUse.Both)
            {
                if (HitWay == HitTactic.ByTurns)
                {
                    if (NextHand) ((TwoHandsWeapon_Controller)(Owner.weapon_controller)).UseWeapon(0);
                    else ((TwoHandsWeapon_Controller)(Owner.weapon_controller)).UseWeapon(1);
                    NextHand = !NextHand;
                }
                else
                {
                    ((TwoHandsWeapon_Controller)(Owner.weapon_controller)).UseWeapon((int)Mathf.Round(Random.value));
                }
            }
            else
            {
                if(UseHand==HandsUse.Left) ((TwoHandsWeapon_Controller)(Owner.weapon_controller)).UseWeapon(0);
                else ((TwoHandsWeapon_Controller)(Owner.weapon_controller)).UseWeapon(1);
            }
        }
    }
    protected override void Update()
    {
        if (!goToTarget())
        {
            Atack();
        }
        _time -= Time.deltaTime;
    }
    public enum HandsUse
    {
        Both,
        Right,
        Left
    }
    protected enum HitTactic
    {
        ByTurns,
        Random
    }
}
