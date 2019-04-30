using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 Корневой клас управления аватаром
 Инкапсулирует статы игрока, инвентарь, состояния интерфейса
 реализует взаимодействие с рабом, инвентарём и кликабельными обьектами
 */
public class Player_Controller: AbstractController {
    public enum InterfaceState
    {
        inGame,
        inInventory,
        inInventoryWithOther
    }

    private Inventory Invent;
    private InterfaceState IState = InterfaceState.inGame;
    private bool CanMove=true;
    public bool CanControl=true;
    public GameObject MessageBox;
    //полоски 
    public GameObject HP_Line;
    public GameObject Mana_Line;
    public GameObject Stamina_Bar;
    public FightSpeakPanel State;

    //цель к которой нужно подойти
    private GameObject target;
    public GameObject Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }
    //положить цель в инвентарь
    public void PutInInventory()
    {
        Invent.Put(target);
    }
    //идти к цели
    private bool MoveToTarget()
    {
        if (target != null)
        {
            Vector2 toTarget = target.transform.position - transform.position;
            if (toTarget.magnitude < target.GetComponent<Clickable>().InteractiveDistanse())
            {
                target.GetComponent<Clickable>().OnInteractive();
                target = null;
                return false;
            }
            Slave.Move(toTarget, _stats._Speed, _stats._AngleStoping);
            return true;
        }
        return false;
    }
    //контроллер ускорения c учётом стамины
    private bool Dash()
    {
        if (!Input.GetKey(KeyCode.Space)) return false;
        float Pay = 2000 * Time.deltaTime;
        if (((Player_Body)(Slave))._MoveState == Player_Body.Move_State.Dash || ((Player_Stats)(_stats)).Stamina == ((Player_Stats)(_stats))._Max_Stamina)
            if (((Player_Stats)(_stats)).Stamina > Pay)
            {
                ((Player_Body)(Slave)).Dash(((Player_Stats)(_stats))._DashSpeed);
                ((Player_Stats)(_stats)).Stamina -= Pay;
            }
            else
            {
                ((Player_Body)(Slave)).Dash(((Player_Stats)(_stats))._DashSpeed / Pay * ((Player_Stats)(_stats)).Stamina);
                ((Player_Stats)(_stats)).Stamina = -1;
                ((Player_Body)(Slave))._MoveState = Player_Body.Move_State.Stay;
            }
        return true;
    }
    //управление клавишами
    private bool MoveWASD()
    {
        Vector2 V = WASD_direction();
        if (V.magnitude == 0) return false;
        Slave.Move(V, _stats._Speed, _stats._AngleStoping);
        return true;
    }
    //управление мышью
    private bool MoveByMouse()
    {
        if (Input.GetMouseButton(1) && !Invent.weapon_controller.Fight || Input.GetKey(KeyCode.LeftShift))
        {
            Slave.Move(Slave.Angle, _stats._Speed, 0);
            return true;
        }
        return false;
    }
    //направление движения из клавиш
    private Vector2 WASD_direction()
    {
        int X = 0, Y = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            Y++;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            Y--;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            X++;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            X--;
        return new Vector2(X, Y);
    }
    private void UpdateLines()
    {
        HP_Line.transform.localScale = new Vector3(Mathf.Max(_stats.HP / _stats._Max_HP,0), 1, 1);
        Mana_Line.transform.localScale = new Vector3(Mathf.Max(((Player_Stats)(_stats)).Mana / ((Player_Stats)(_stats))._Max_Mana,0), 1, 1);
        Stamina_Bar.transform.GetChild(0).transform.localScale = new Vector3(((Player_Stats)(_stats)).Stamina / ((Player_Stats)(_stats))._Max_Stamina, 1, 1);
    }
    private void ShowHideInventory()
    {
        Invent.UI_ThisInventory.SetActive(!Invent.UI_ThisInventory.activeSelf);
        if (Invent.UI_ThisInventory.activeSelf)
        {
            Invent.HideItemInfo();
            Invent.UI_OtherInventory.SetActive(false);
            IState = InterfaceState.inInventory;
        }
        else
        {
            IState = InterfaceState.inGame;
        }
    }
    //открытие сундука/торговца
    public void ShowInventoryWithOther(List<GameObject> OtherInvent)
    {
        Invent.UI_ThisInventory.SetActive(true);
        Invent.ShowOtherInventory(OtherInvent);
        IState = InterfaceState.inInventoryWithOther;
    }
    private void UpdateMovement()
    {
        if (CanMove&&IState!=InterfaceState.inInventoryWithOther)
        {
            bool flagDelTarget = true;
            if (!Dash()) if (!MoveWASD()) if (!MoveByMouse())
                    {
                        MoveToTarget();
                        flagDelTarget = false;
                    }

            if (flagDelTarget) target = null;
            ((Player_Body)(Slave)).LookAtMouse();
        }
    }
    //взаимодействие с кликабельными обьектами в игровом мире
    public void Interaction()
    {
        int MaskLayer = 1 << 8;
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition), 50, MaskLayer);
        if (Input.GetMouseButtonDown(0))
            if (rayHit.collider != null)
                rayHit.collider.gameObject.GetComponent<Clickable>().OnClick();
    }

    void Start () {
        Slave = GetComponent<Player_Body>();
        Invent = GetComponent<Inventory>();
        Invent.UI_ThisInventory.SetActive(false);
	}

    protected override void Update()
    {
        base.Update();
        _stats.UpdateStats();
        UpdateLines();
        if(CanControl){
            if (Input.GetKeyUp(KeyCode.Tab)) ShowHideInventory();
            UpdateMovement();
            if (IState == InterfaceState.inGame)
            {
                if (!Invent.weapon_controller.Fight) Interaction();
                if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetMouseButtonUp(2))
                {
                    ResetWeapon(!Invent.weapon_controller.Fight);
                }
            }

            if (Invent.weapon_controller.Fight&&IState==InterfaceState.inGame)
            {
                if (Input.GetMouseButtonDown(0)) Invent.weapon_controller.UseWeapon(0);
                if (Input.GetMouseButtonDown(1)) Invent.weapon_controller.UseWeapon(1);
            }
        }
    }
    public void ResetWeapon(bool flag)
    {
        if (flag)
        {
            Invent.weapon_controller.WeaponOn();
            MessageBox.GetComponent<MessageController>().ShowMessage("Боевой режим", 3);
            State.Set(true);
        }
        else
        {
            Invent.weapon_controller.WeaponOff();
            MessageBox.GetComponent<MessageController>().ShowMessage("Мирный режим", 3);
            State.Set(false);
        }
    }
}
