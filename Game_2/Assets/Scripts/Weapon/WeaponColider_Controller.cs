using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColider_Controller : WeaponColider_Trigger
{
    void Update()
    {
        if (_weapon.HandController != null)
        { 
            Vector3 V =transform.parent.position+ Vector3.down*_weapon.HandController.HandsHeight;
            transform.position = V;
        }
    }
}