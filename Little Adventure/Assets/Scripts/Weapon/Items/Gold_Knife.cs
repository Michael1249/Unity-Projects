using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Knife : Weapon
{
    public override string Discription()
    {
        return "\fХЗолотой клинок\nОружие не для бедных";
    }

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 4;
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
        return new string[] { "Золотой клинок", "Урон", "4", "Быстрое оружие", "", "ближнего боя" };
    }

    protected override void OnAtack()
    {

    }

}

