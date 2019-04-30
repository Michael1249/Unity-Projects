using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron_Sword : Weapon
{
    public override string Discription()
    {
        return "\fЖелезный Меч\nDeus vult!";
    }

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 12;
    }

    public override float getRepulsion()
    {
        return 900;
    }

    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Железный меч", "Урон", "12", "", "", "" };
    }

    protected override void OnAtack()
    {

    }

}
