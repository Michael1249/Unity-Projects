using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Sword : Weapon
{
    public override string Discription()
    {
        return "\fОгромный Меч\nОн тяжелее меня";
    }

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 20;
    }

    public override float getRepulsion()
    {
        return 3000;
    }


    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Огромный меч", "Урон", "20", "", "", "" };
    }

    protected override void OnAtack()
    {

    }

}