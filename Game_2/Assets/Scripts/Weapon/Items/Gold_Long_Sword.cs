using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Long_Sword : Weapon
{
    public override string Discription()
    {
        return "\fЭлитный Меч\nЭто для меня";
    }

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 17;
    }

    public override float getRepulsion()
    {
        return 2000;
    }


    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Элитный меч", "Урон", "17", "", "", "" };
    }

    protected override void OnAtack()
    {

    }

}
