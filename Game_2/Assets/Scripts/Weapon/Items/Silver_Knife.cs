using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver_Knife : Weapon
{
    public override string Discription()
    {
        return "\fХБлестящий клинок\nЖалко кровью пачкать";
    }

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 5;
    }

    public override float getRepulsion()
    {
        return 600;
    }

 

    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Стальной клинок", "Урон", "5", "Быстрое оружие", "", "ближнего боя" };
    }

    protected override void OnAtack()
    {

    }

}
