using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rapier : Weapon
{
    public override string Discription()
    {
        return "\fРапира\nТык, тык...";
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
        return 500;
    }


    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Рапира", "Урон", "4", "Быстрое оружие", "", "для дуэли" };
    }

    protected override void OnAtack()
    {

    }

}

