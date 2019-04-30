using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 Корневой клас для всех итемов
 знает что делать при взаимодействии и количество в стаке
 все потомки реализуют остальные методы
 */
public abstract class Inventory_Item : Clickable
{
    public int _Count;

    public SimpleEvent OnUseEvent;
    public SimpleEvent OnInteractiveEvent;
    public virtual Sprite GetSprite()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }
    public virtual void OnReplace() { }

    public override void OnInteractive()
    {
        Player().GetComponent<Player_Controller>().PutInInventory();
        Player().GetComponent<Inventory>().UpdateUI_Inventory();
        if (gameObject.GetComponent<Collider2D>() != null) Destroy(gameObject.GetComponent<Collider2D>());
        if (OnInteractiveEvent != null) OnInteractiveEvent.Invoke();
    }


    //public abstract int ID();
    public abstract bool Stackable();
    public abstract string Discription();
    public virtual void OnUse()
    {
        if (OnUseEvent != null) OnUseEvent.Invoke();
    }
    public abstract string[] Stats();

}
