using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Short_Sword : Weapon
{
    public override string Discription()
    {
        return "\fКороткий меч\nЛегковат для меня";
    }

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 7;
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
        return new string[] { "Короткий Меч", "Урон", "7", "Универсальное", "", "оружие" };
    }

    protected override void OnAtack()
    {

    }

}
