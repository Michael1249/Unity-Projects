using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : Weapon
{
    public override string Discription()
{
    return "\fКатана\nОружие скрытного воина";
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
    return 1000;
}



public override bool Stackable()
{
    return false;
}

public override string[] Stats()
{
    return new string[] { "Катана", "Урон", "12", "", "", "" };
}

protected override void OnAtack()
{

}

}
