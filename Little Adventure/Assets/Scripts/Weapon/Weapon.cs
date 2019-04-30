using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Weapon : Inventory_Item {
    protected bool _isUse = false;
    protected bool _isAtacking = false;
    protected bool _ShowHand = true;
    public GameObject SoundAtack;
    public bool IsAtacking
    {
        get
        {
            return _isAtacking;
        }
    }

    public BodyHandsController HandController
    {
        get
        {
            return _handController;
        }

        set
        {
            _handController = value;
        }
    }

    public bool IsUse
    {
        get
        {
            return _isUse;
        }
    }

    [HideInInspector]
    public GameObject HandTarget;
    [HideInInspector]
    public HandDirection _HandDir;
    [HideInInspector]
    public Stats _stats;
    //увеличение значения ведёт к движению руки в сторону цели
    [HideInInspector]
    public float HandAngleDelta;
    private BodyHandsController _handController;
    [HideInInspector]
    public float AngleChange = -20;
    void FixedUpdate()
    {
        UpdateWeapon();
        if (_isUse)
        {
            float Delta = AngleChange * 2 * ((int)_HandDir - 0.5f);
            this.transform.localEulerAngles = new Vector3(0, 0, _handController.Angle + Delta - 90);
        }
    }


    public abstract float getPhisicalDamag();
    public abstract float getMagicDamag();
    public abstract float getRepulsion();
    public void OnHide() {
        GetComponent<Animator>().Play("Hide");
    }
    public void OnShow() {
        GetComponent<Animator>().Play("Show");
    }

    public virtual void OnStartAtack()
    {
        GetComponent<Animator>().SetBool("StartAtack", true);
        _isAtacking = true;
        if(SoundAtack)
        Instantiate(SoundAtack,transform);
    }
    protected abstract void OnAtack();
    protected virtual void OnEndAtack()
    {
        GetComponent<Animator>().SetBool("StartAtack", false);
        _isAtacking = false;
        HandAngleDelta = 90;
    }


    protected void UpdateWeapon()
    {
        if (IsAtacking)
        {
            if (_handController != null)
                if (_HandDir != HandDirection.Left)
                    _handController.AngleDelta = HandAngleDelta;
                else
                    _handController.AngleDelta = -HandAngleDelta;
            
        }
    }
    private void InitWeaponOpt() {
        GetComponent<Animator>().enabled = true;
        GetComponent<SpriteRenderer>().sortingOrder = 10;
    }
    //для использования игроком
    public override void OnUse()
    {
        TwoHandsWeapon_Controller scils= Player().GetComponent<Inventory>().weapon_controller;
        if (_isUse)
        {
            scils.Del(this);
            _isUse = false;
            _isAtacking = false;
        }
        else
        {
            _isUse = scils.Add(this);
            if (_isUse)
            {
                _stats= Player().GetComponent<Stats>();
                InitWeaponOpt();
                _handController = Player().GetComponent<BodyHandsController>();
                SetHand(scils);
            }
        }
    }
    //для использования ботом
    public void OnUse(TwoHandsWeapon_Controller scils,BodyHandsController bodyHands,Stats _stats)
    {
        if (_isUse)
        {
            scils.Del(this);
            _isUse = false;
            _isAtacking = false;
        }
        else
        {
            _isUse = scils.Add(this);
            if (_isUse)
            {
                this._stats = _stats;
                InitWeaponOpt();
                _handController = bodyHands;
                SetHand(scils);
            }
        }
    }
    public void SetHand(TwoHandsWeapon_Controller scils)
    {
       _HandDir = (HandDirection)scils.Index(this);
        if(scils.Index(this)==0)
            HandTarget = _handController.HandL;
        else
            HandTarget = _handController.HandR;
        this.gameObject.transform.parent = HandTarget.transform;
        if(_ShowHand)
        this.gameObject.transform.localPosition = new Vector3(0, 0, 0.01f);
        else this.gameObject.transform.localPosition = new Vector3(0, 0, -0.01f);

    }
    public enum HandDirection
    {
        Left,
        Right
    }

    public override void OnInteractive()
    {
        base.OnInteractive();
        GetComponent<SpriteRenderer>().sortingOrder = 10;
        GetComponent<Animator>().enabled = true;
    }
    public override void OnReplace()
    {
        if (_isUse)
        {
            TwoHandsWeapon_Controller scils = Player().GetComponent<Inventory>().weapon_controller;
            scils.Del(this);
            _isUse = false;
        }
    }

    public override float InteractiveDistanse()
    {
        return 0.8f;
    }
}
