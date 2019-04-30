using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel_Sword : Weapon
{
    public override string Discription()
    {
        return "\fСтальной Меч\nПрочный";
    }

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 14;
    }

    public override float getRepulsion()
    {
        return 1000;
    }

   

    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Стальной меч", "Урон", "14", "", "", "" };
    }

    protected override void OnAtack()
    {

    }

}
