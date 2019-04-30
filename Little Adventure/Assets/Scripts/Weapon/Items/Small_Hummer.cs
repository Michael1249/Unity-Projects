using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small_Hummer : Weapon
{
    public override string Discription()
    {
        return "\fИм можно забивать гвозди...\n...в черепа моих врагов";
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
        return 800;
    }

    

    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Железный Молот", "Урон", "3", "Грубое оружие", "", "ближнего боя" };
    }

    protected override void OnAtack()
    {

    }

}

