using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Sword : Weapon
{
    public override string Discription()
    {
        return "\fЗолотой Меч\nПрочный";
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
        return 1200;
    }

  

    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Золотой меч", "Урон", "12", "", "", "" };
    }

    protected override void OnAtack()
    {

    }

}