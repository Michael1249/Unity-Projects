using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaelthExtract_Item : Inventory_Item
{
    public override string Discription()
    {
        return "\fЭкстракт Жизни\nОт смерти всё равно не спасёт";
    }

    public override float InteractiveDistanse()
    {
        return 0.7f;
    }

    public override void OnUse()
    {
        Player().GetComponent<Player_Stats>().HP += 20;
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
        return new string[] {"Экстракт Жизни","Здоровье","+20"};
    }
}

