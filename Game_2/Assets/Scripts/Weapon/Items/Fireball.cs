using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Weapon
{
    private float ManaCost = 5;
    public GameObject Ball_Prefab;
    public override string Discription()
    {
        return "\fФаербол\n";
    }

    public override float getMagicDamag()
    {
        return 5;
    }

    public override float getPhisicalDamag()
    {
        return 0;
    }

    public override float getRepulsion()
    {
        return 100;
    }



    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Огненный шар", "Магия", "5" };
    }
    void Awake()
    {
        _ShowHand = false;
    }
    protected override void OnAtack()
    {
        Player_Stats PS = HandController.GetComponent<Player_Stats>();
        if (PS != null) {
            if (PS.Mana < ManaCost) return;
            PS.Mana -= ManaCost; }
        Weapon _weapon =(Weapon) this.MemberwiseClone();
        //Weapon _weapon = Instantiate(this);
        GameObject ball = Instantiate(Ball_Prefab);
        ball.transform.position = transform.position;
        ball.transform.localEulerAngles = new Vector3(0, 0, HandController.Angle - 90);
        //_weapon.gameObject.SetActive(false);
        //_weapon.HandController = this.HandController;
        ball.GetComponentInChildren<WeaponColider_Trigger>()._weapon = _weapon;
    }

}
