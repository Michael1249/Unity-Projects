using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Hummer : Weapon
{
    public override string Discription()
    {
        return "Кувалда\nНе уверен что подниму";
    }

    public override float getMagicDamag()
    {
        return 0;
    }

    public override float getPhisicalDamag()
    {
        return 30;
    }

    public override float getRepulsion()
    {
        return 10;
    }


    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Большой молот", "Боковой удар", "50", "Скорость", "3" };
    }

    protected override void OnAtack()
    {

    }

}