using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Inventory_Item
{
    public string _discription;
    public override string Discription()
    {
        return "\fКлюч\n"+_discription;
    }

    public override float InteractiveDistanse()
    {
        return 0.5f;
    }
    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Ключ", "Им можно открывать","", "замки" };
    }
}
