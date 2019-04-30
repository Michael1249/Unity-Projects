using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider_Trigger : Basic_Trigger {

    [Header("Filter")]
    public bool Player;
    public bool Enemy;
    public bool Neitral;
    [HideInInspector]
    public List<Collider2D> Others;
    [SerializeField]
    private Stats _stats;
    public SimpleEvent OnTrigger;
    public SimpleEvent OffTrigger;

    public override bool TriggerEnable
    {
        get
        {
            return triggerEnable;
        }

        set
        {
            if (value == true)
            {
                Others = new List<Collider2D>();
                _active = false;
            }
            triggerEnable = value;
        }
    }
    void Start()
    {
        Others = new List<Collider2D>();
    }
    private bool setActiveWithFilter(Collider2D other)
    {
        if(Player)
        if (other.gameObject.tag == "Player") return true;
        AbstractController AC = other.gameObject.GetComponent<AbstractController>();
        if (AC != null)
        {
            if(Neitral)
            if (AC._stats._Fraction == Fraction.Neitral) return true;
            if(Enemy)
            if (AC._stats._Fraction != _stats._Fraction &&
                AC._stats._Fraction != Fraction.Neitral) return true;
        }
            return false;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(TriggerEnable)
        if (setActiveWithFilter(other))
        {
                if(Others.IndexOf(other)==-1)
                Others.Add(other);
                if (Others.Count == 1&&!_active)
                {
                    _active = true;
                    if (OnTrigger != null) { OnTrigger.Invoke(); }
                }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (TriggerEnable)
        {
            Others.Remove(other);
            if (Others.Count==0&&_active==true)
            {
                _active = false;
                if (OffTrigger != null) {OffTrigger.Invoke();}
            }
        }
    }
    //void Update()
    //{
    //    if (AC != null)
    //        if (!AC.enabled)
    //        {
    //            _active = false;
    //            if (OffTrigger != null) OffTrigger.Invoke();
    //        }
    //}
}
