using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Rusty : Weapon
{
    public override string Discription()
    {
        return "\fРжавый Меч\nЯ не первый кто его держу";
    }

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 10;
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
        return new string[] { "Ржавый меч", "Урон", "10", "", "", "" };
    }

    protected override void OnAtack()
    {

    }

}
