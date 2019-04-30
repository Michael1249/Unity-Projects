using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron_Knife :Weapon
{
    public override string Discription()
{
    return "\fЖелезный ножичек\nТакие быстро ржавеют";
}

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 3;
    }

    public override float getRepulsion()
    {
        return 500;
    }



public override bool Stackable()
{
    return false;
}

public override string[] Stats()
{
    return new string[] {"Железный нож","Урон","3","Быстрое оружие","","ближнего боя"};
}

protected override void OnAtack()
    {
       
    }

}
