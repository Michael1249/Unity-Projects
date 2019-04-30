using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandsWeapon_Controller :Weapon_Controller{
    [SerializeField]
    private List<Weapon> Weapons;
    public bool Fight
    {
        get
        {
            return _fight;
        }
    }
    [HideInInspector]
    public Animator DefoultWeaponAnimator;
    //private bool Started = false;
    void Start()
    {
        //if (!Started)
        {
            //Started = true;
            List<Weapon> copy = Weapons;
            Weapons = new List<Weapon>();
            foreach (Weapon item in copy)
            {
                item.gameObject.SetActive(false);
                item.OnUse(this, GetComponent<BodyHandsController>(), GetComponent<Stats>());

            }
        }
        DefoultWeaponAnimator = GetComponent<Animator>();
    }
    public void ResetWeapon()
    {

        for (int i = Weapons.Count-1; i>-1; i--)
        {
            Weapon now = Weapons[i];
            if (now.IsUse)
            {
                now.OnUse(this, GetComponent<BodyHandsController>(), GetComponent<Stats>());
                now.gameObject.SetActive(true);
            }
        }
    }
    public bool Add(Weapon GO)
    {
        if (Weapons.Count < 2)
        {
            Weapons.Add(GO);
            GO.gameObject.SetActive(true);
            if (!Fight) GO.OnHide();
            else GO.OnShow();
            return true;
        }
        return false;
    }
    public void Del(Weapon GO)
    {
        GO.gameObject.SetActive(false);
        Weapons.Remove(GO);
        if (Weapons.Count == 1) Weapons[0].SetHand(this);
    }
    public int Index(Weapon GO)
    {
        return Weapons.IndexOf(GO);
    }
    public void UseWeapon(int indx)
    {
        if (!DefoultWeaponAnimator.GetCurrentAnimatorStateInfo(1).IsName("HandIdle")) return;
        if (Weapons.Count > 0) if (Weapons[0].IsAtacking) return;
        if (Weapons.Count == 2) if (Weapons[1].IsAtacking) return;
            if (Weapons.Count == 0)
        {
                if (indx == 0) DefoultWeaponAnimator.Play("HandHit_L");
                else DefoultWeaponAnimator.Play("HandHit_R");
        }
        else if (Weapons.Count == 1)
        {
            if (indx == 0) Weapons[0].OnStartAtack();
            else DefoultWeaponAnimator.Play("HandHit_R");
        }
        else
        {
            if (indx == 0) Weapons[0].OnStartAtack();
            else Weapons[1].OnStartAtack();
        }
    }
    public override void WeaponOn()
    { 
        base.WeaponOn();
        if (Weapons.Count == 0) return;
        if (Weapons.Count == 1) Weapons[0].OnShow();
        else
        {
            Weapons[0].OnShow();
            Weapons[1].OnShow();
        }
    }
    public override void WeaponOff()
    {
        base.WeaponOff();
        if (Weapons.Count == 0) return;
        if (Weapons.Count == 1) Weapons[0].OnHide();
        else
        {
            Weapons[0].OnHide();
            Weapons[1].OnHide();
        }
    }
    //for player
    public void UpdateUI(GameObject UI)
    {
        if (Weapons.Count > 0)
        {
            UI.transform.GetChild(0).gameObject.SetActive(true);
            UI.transform.GetChild(0).GetComponent<InventoryBtnController>().SetGameObject(Weapons[0].gameObject);
            if (Weapons.Count > 1)
            {
                UI.transform.GetChild(1).gameObject.SetActive(true);
                UI.transform.GetChild(1).GetComponent<InventoryBtnController>().SetGameObject(Weapons[1].gameObject);
            }
            else
                UI.transform.GetChild(1).gameObject.SetActive(false);

        }
        else
        {
            UI.transform.GetChild(0).gameObject.SetActive(false);
            UI.transform.GetChild(1).gameObject.SetActive(false);

        }
    }
    
}
