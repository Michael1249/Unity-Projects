using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColider_Trigger : MonoBehaviour {

    public Weapon _weapon;
    public bool DestroyOnTrigger = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        AbstractController Enemy = other.GetComponent<AbstractController>();
        if (Enemy != null)
        {

            if (Enemy._stats._Fraction != _weapon._stats._Fraction&& Enemy._stats._Fraction != Fraction.Neitral)
            {
                Enemy._stats.PhisicalDamag(_weapon._stats.getPhisicalDamag() * _weapon.getPhisicalDamag());
                Enemy._stats.MagicDamag(_weapon._stats.getMagicDamag() * _weapon.getMagicDamag());
                Vector2 Dir = Enemy.transform.position - _weapon.HandController.transform.position;
                if(Enemy.GetComponent<Rigidbody2D>()!=null)
                Enemy.GetComponent<Rigidbody2D>().AddForce(Dir / Dir.magnitude * _weapon.getRepulsion());
                if (DestroyOnTrigger)
                {
                    //Destroy(_weapon.gameObject);
                    transform.parent.GetComponent<Abstract_MoveSet>().DestroyBall();
                }
            }
            
        }

    }
}
