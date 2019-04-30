using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandColider_Controller : MonoBehaviour {

    public Stats _stats;
    void OnTriggerEnter2D(Collider2D other)
    {
            AbstractController Enemy = other.GetComponent<AbstractController>();
            if (Enemy != null)
            {
                if (Enemy._stats._Fraction != _stats._Fraction)
                {
                Enemy._stats.PhisicalDamag(_stats.getPhisicalDamag() * _stats._HandDamag);
                }
            }
    }
}
