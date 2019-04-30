using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machete : Weapon
{
    public override string Discription()
    {
        return "\fМачете\nЖалко сегодня не пятница";
    }

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 9;
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
        return new string[] { "Мачете", "Урон", "9", "Нужно хорошо", "", "замахнуться" };
    }

    protected override void OnAtack()
    {

    }

}

