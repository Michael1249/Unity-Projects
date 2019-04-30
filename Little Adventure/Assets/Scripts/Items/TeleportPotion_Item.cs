using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPotion_Item : Inventory_Item
{
    public override string Discription()
    {
        return "\fЗелье Телепортации\nВесёлая штука";
    }

    public override float InteractiveDistanse()
    {
        return 1;
    }

    public override void OnUse()
    {
        base.OnUse();
        Destroy(this.gameObject);
    }

    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Зелье Телепортации", "???", "???" };
    }
}



