using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Item : Inventory_Item
{
    public override string Discription()
    {
        return "\fЗолото\nДумаю понятно как это работает";
    }

    public override float InteractiveDistanse()
    {
        return 0.8f;
    }

    public override void OnUse()
    {
       
    }

    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return null;//new string[] {"Золото","Богатство","+1"};
    }
}
