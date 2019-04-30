using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Controller : AbstractController {

    [SerializeField]
    public TwoHandsWeapon_Controller weapon_controller;
    [SerializeField]
    private bool OffWeaponsOnDead;
    [SerializeField]
    private List<AI_Behevior> Beheviors;
    void Start () {
        Slave = GetComponent<BodyController>();
    }
    //protected override void Update()
    //{
    //    if (!NowBehevior.LockBehavior)
    //    {
    //        AI_Behevior Next = NowBehevior;
    //        foreach (AI_Behevior _behavior in Beheviors)
    //        {
    //            if (_behavior.getPriority() > Next.getPriority() && _behavior.isTriggered()) Next = _behavior;
    //        }
    //        if (!Next.Equals(NowBehevior))
    //        {
    //            NowBehevior.SetActivBeh(false);
    //            NowBehevior = Next;
    //            NowBehevior.SetActivBeh(true);
    //        }
    //    }
    //    base.Update();

    //}

    public override void OnDead()
    {
        foreach (AI_Behevior _behavior in Beheviors)
        {
            _behavior.enabled = false;
            if(_behavior._trigger!=null)
            _behavior._trigger.TriggerEnable=false;
        }
        if (OffWeaponsOnDead)
        {
            weapon_controller.WeaponOff();
        }
        else
        {
            if(weapon_controller!=null)
            weapon_controller.ResetWeapon();
        }
        base.OnDead();

    }
    public void End()
    {
        GetComponent<Animator>().Play("End");
    }

}
