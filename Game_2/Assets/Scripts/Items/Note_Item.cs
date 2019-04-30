using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Item : Inventory_Item
{
    public Note_Controller controller;
    public string _discription;
    public string message;
    public Sprite picture;
    public override string Discription()
    {
        return  _discription;
    }

    public override void OnUse()
    {
        base.OnUse();
        if (controller.Status)
            controller.EndAnim();
        else if (picture)
            controller.StartNote(picture);
        else
            controller.StartNote(message);

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
        return new string[] { "Свиток", "Полезная", "", "информация" };
    }
}

