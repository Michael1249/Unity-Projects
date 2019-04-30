using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Fraction
{
    Neitral,
    Good,
    Bad
}
public class Stats:MonoBehaviour
{
    public bool SpawnBlood = true;
    public GameObject[] Blood;
    public float _Lvl = 0;
    public Fraction _Fraction = Fraction.Neitral;
    public float _Speed = 5000;
    public float _AngleStoping = 0.5f;
    [SerializeField][HideInInspector]
    private float _HP = 100;
    public float _Max_HP = 100;
    public float _HandDamag = 3;
    public float _Forse = 10;
    public float _Armor = 0;
    public float _Magic = 10;
    public float _PsiArmor = 0;
    public SimpleEvent OnHitEvent;
    public float HP_Percent()
    {
        return 100 * HP / _Max_HP;
    }
    public float HP
    {
        get
        {
            return _HP;
        }

        set
        {
            if (value <= 0) _HP = 0;
            else if (value > _Max_HP) _HP = _Max_HP;
            else _HP = value;
        }
    }

    public virtual void UpdateStats() { }
    private void Hit(float value,float armor)
    {
        HP -= value / (_Lvl / 10 + 1) * (100 - armor) / 100;
        InitBlood();
        if (OnHitEvent != null) OnHitEvent.Invoke();
    }
    public void PhisicalDamag(float value)
    {
        Hit(value, _Armor);
    }
    public void MagicDamag(float value)
    {
        Hit(value, _PsiArmor);
    }
    public virtual float getPhisicalDamag()
    {
        return _Forse /10* (_Lvl / 10 + 1);
    }
    public float getMagicDamag()
    {
        return _Magic /10* (_Lvl / 10 + 1);
    }
    private void InitBlood()
    {
        if(SpawnBlood)
        if (Blood.Length != 0)
        {
            GameObject _blood = Instantiate(Blood[(int)(Random.value * Blood.Length)],transform.parent);
            _blood.transform.position = transform.position + new Vector3(Random.value - 0.5f, Random.value - 0.5f,500);
        }
    }
}

