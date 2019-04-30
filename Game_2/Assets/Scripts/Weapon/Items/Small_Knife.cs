using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small_Knife :Weapon
{
    public GameObject Ball_Prefab;
    public override string Discription()
{
    return "\fМетательный нож\n";
}

public override float getMagicDamag()
{
    return 0;
}

public override float getPhisicalDamag()
{
    return 3;
}

public override float getRepulsion()
{
    return 500;
}



public override bool Stackable()
{
    return false;
}

public override string[] Stats()
{
    return new string[] { "Метательный нож", "Урон", "3"};
}

protected override void OnAtack()
{
        _Count--;
        GameObject ball=Instantiate(Ball_Prefab);
        ball.transform.position = transform.position;
        ball.transform.localEulerAngles = new Vector3(0, 0, HandController.Angle-90);
        Weapon _weapon = (Weapon)this.MemberwiseClone();
        //Weapon _weapon= Instantiate(this);
        //_weapon.gameObject.SetActive(false);
        //_weapon.HandController=this.HandController;
        ball.GetComponentInChildren<WeaponColider_Trigger>()._weapon = _weapon;
        if (_Count == 0) {
            OnUse();
            Destroy(this.gameObject);
        }
    }

}

