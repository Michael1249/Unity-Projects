using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire5Targetball : Weapon
{
    private float ManaCost = 15;
    public GameObject Ball_Prefab;
    public override string Discription()
    {
        return "\fОгненный Шторм\n";
    }

    public override float getMagicDamag()
    {
        return 3;
    }

    public override float getPhisicalDamag()
    {
        return 0;
    }

    public override float getRepulsion()
    {
        return 300;
    }



    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Огненный Шторм", "Магия", "5" };
    }
    void Awake()
    {
        _ShowHand = false;
    }
    protected override void OnAtack()
    {
        Player_Stats PS = HandController.GetComponent<Player_Stats>();
        if (PS != null)
        {
            if (PS.Mana < ManaCost) return;
            PS.Mana -= ManaCost;
        }
        for (int i = 0; i < 5; i++)
        {
            Weapon _weapon = (Weapon)this.MemberwiseClone();
            //Weapon _weapon = Instantiate(this);
            GameObject ball = Instantiate(Ball_Prefab);
            ball.transform.position = HandController.transform.position+new Vector3(
                Mathf.Cos((HandController.Angle + (i+1)*72)*Mathf.Deg2Rad),
                Mathf.Sin((HandController.Angle + (i+1)*72)*Mathf.Deg2Rad),50);
            ball.transform.localEulerAngles = new Vector3(0, 0, HandController.Angle + 90 + i*72);
                ball.GetComponent<GravityTargetFly>().target = HandController.transform;
            //_weapon.gameObject.SetActive(false);
            //_weapon.HandController = this.HandController;
            ball.GetComponentInChildren<WeaponColider_Trigger>()._weapon = _weapon;
        }
    }

}