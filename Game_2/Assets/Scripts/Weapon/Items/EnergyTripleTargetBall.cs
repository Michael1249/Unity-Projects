using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTripleTargetBall : Weapon
{
    private float ManaCost = 30;
    public GameObject Ball_Prefab;
    public override string Discription()
    {
        return "\fСгустки энергии\n";
    }

    public override float getMagicDamag()
    {
        return 10;
    }

    public override float getPhisicalDamag()
    {
        return 0;
    }

    public override float getRepulsion()
    {
        return 150;
    }



    public override bool Stackable()
    {
        return false;
    }

    public override string[] Stats()
    {
        return new string[] { "Энергетические шары", "Магия", "10" };
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
        for (int i = 0; i < 3; i++)
        {
            Weapon _weapon = (Weapon)this.MemberwiseClone();
            //Weapon _weapon = Instantiate(this);
            GameObject ball = Instantiate(Ball_Prefab);
            ball.transform.position = transform.position;
            ball.transform.localEulerAngles = new Vector3(0, 0, HandController.Angle + 90 + Random.Range(-40, 40));
            float direction = HandController.Angle;
            ball.GetComponent<GravityFly_AnimDead>().dir = new Vector2(Mathf.Cos(direction * Mathf.Deg2Rad), Mathf.Sin(direction * Mathf.Deg2Rad));
            if(HandController.GetComponent<SmartAtack>()!= null)
            ball.GetComponent<GravityTargetFly>().target = HandController.GetComponent<SmartAtack>().GetTarget();
            //_weapon.gameObject.SetActive(false);
            //_weapon.HandController = this.HandController;
            ball.GetComponentInChildren<WeaponColider_Trigger>()._weapon = _weapon;
        }
    }

}