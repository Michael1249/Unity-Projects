using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaExtract_Item : Inventory_Item
{
    public override string Discription()
    {
        return "\fЭкстракт Маны\nНа вкус как ликёр";
    }

    public override float InteractiveDistanse()
    {
        return 0.7f;
    }

    public override void OnUse()
    {
        Player().GetComponent<Player_Stats>().Mana += 20;
        _Count--;
        if (_Count == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public override bool Stackable()
    {
        return true;
    }

    public override string[] Stats()
    {
        return new string[] { "Экстракт Маны", "Мана", "+20" };
    }
}
