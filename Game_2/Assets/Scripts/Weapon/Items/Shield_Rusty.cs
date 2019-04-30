using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Rusty:Weapon
{

public override string Discription()
    {
        return "\fРжавый Баклер\nЭтот щит слишком мал для меня";
    }
public override float getMagicDamag()
{
    return 0;
}

public override float getPhisicalDamag()
{
    return 1;
}

public override float getRepulsion()
{
    return 1500;
}
    [SerializeField]
    private Sprite picture;
    public override Sprite GetSprite()
    {
        return picture;
    }

    public override void OnUse()
    {
        base.OnUse();
        if (_isUse) _stats._Armor += 5;
        else _stats._Armor -= 5;
    }

    public override bool Stackable()
{
    return false;
}

public override string[] Stats()
{
    return new string[] { "Ржавый Баклер", "Урон", "1", "Защита", "5%" };
}

protected override void OnAtack()
{

}

}

