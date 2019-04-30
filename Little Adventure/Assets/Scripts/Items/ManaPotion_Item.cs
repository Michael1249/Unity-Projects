using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion_Item : Inventory_Item
{
    public override string Discription()
    {
        return "\fЗелье Маны\nКрепкий отвар";
    }

    public override float InteractiveDistanse()
    {
        return 0.7f;
    }

    public override void OnUse()
    {
        Player().GetComponent<Player_Stats>().Mana += 50;
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
        return new string[] { "Зелье Маны", "Мана", "+50" };
    }
}

