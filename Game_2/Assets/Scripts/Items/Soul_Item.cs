using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul_Item : Inventory_Item
{
    public override string Discription()
    {
        return "\fЗаблудшая душа\n";
    }

    public override float InteractiveDistanse()
    {
        return 0.7f;
    }

    public override void OnUse()
    {
        
    }

    public override bool Stackable()
    {
        return true;
    }

    public override string[] Stats()
    {
        return null;// new string[] { "Экстракт Маны", "Мана", "+20" };
    }
}
