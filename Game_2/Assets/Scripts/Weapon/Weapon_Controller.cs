using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Controller : MonoBehaviour {
    protected bool _fight = false;


    public virtual void WeaponOn()
    {
        _fight = true;
    }
    public virtual void WeaponOff()
    {
        _fight = false;
    }
}
