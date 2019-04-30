using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*
 Клас реализующий инвентарь игрока, взаимодействие с чужими инвентарями и с UI
 This - то что относиться к инвентарю игрока
 Other - чужие
     */
public class Inventory : MonoBehaviour {

    public GameObject ButtonPrefab;
    private GameObject[] Buttons;
    private GameObject[] OtherButtons;
    private List<GameObject> ThisInventory;
    private List<GameObject> OtherInvent;
    public GameObject UI_ThisInventory;
    public GameObject Discription_Panel;
    public GameObject Image_Panel;
    public GameObject Stats_Panel;
    public GameObject UI_OtherInventory;
    public GameObject Weapon_Panel;
    //[HideInInspector]
    public TwoHandsWeapon_Controller weapon_controller;

    private int ThisScrol = 0;
    private int OtherScrol = 0;
    //мышь в верхней части экрана?
    private bool MouseInTop;

    //наследник Button для клика и показа описания предмета
    private class InventoryButton : UnityEngine.UI.Button
    {
        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            GetComponent<InventoryBtnController>().ShowDiscription();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            GetComponent<InventoryBtnController>().OnClick();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            GetComponent<InventoryBtnController>().HideDiscription();
        }

    }
    //положить обьект в инвентарь свой или чужой
    private void Put(GameObject GO,List<GameObject>list)
    {
        if(GO.GetComponent<Inventory_Item>().Stackable())
        {
            int num = NumberByItem(GO.GetComponent<Inventory_Item>(),list);
            if (num != -1)
            {
                list[num].GetComponent<Inventory_Item>()._Count+= GO.GetComponent<Inventory_Item>()._Count;
                Destroy(GO);
                return;
            }
        }
        list.Add(GO);
        GO.SetActive(false);
    }
    //откытый вариант для своего инвентаря
    public void Put(GameObject GO)
    {
        if (GO.GetComponent<Inventory_Item>().Stackable())
        {
            int num = NumberByItem(GO.GetComponent<Inventory_Item>(), ThisInventory);
            if (num != -1)
            {
                ThisInventory[num].GetComponent<Inventory_Item>()._Count += GO.GetComponent<Inventory_Item>()._Count;
                Destroy(GO);
                UpdateUI_Inventory();
                return;
            }
        }
        ThisInventory.Add(GO);
        GO.SetActive(false);
    }
    public bool TakeOne(GameObject GO)
    {
        return ThisInventory.Remove(GO);
    }
    public void UpdateUI_Inventory()
    {
        for (int i = 0; i < 36; i++)
        {
            if (i+ThisScrol < ThisInventory.Count)
            {
                if (ThisInventory[i + ThisScrol] == null) { ThisInventory.RemoveAt(i + ThisScrol); i--; }
                else
                    Buttons[i].GetComponent<InventoryBtnController>().SetGameObject(ThisInventory[i + ThisScrol]);
            }
            else
            {
                Buttons[i].SetActive(false);
            }
        }
    }
    //начало взаимодействия с чужим инвентарём
    public void ShowOtherInventory(List<GameObject> otherIvent)
    {
        UI_OtherInventory.SetActive(true);
        this.OtherInvent = otherIvent;
        OtherScrol = 0;
        UpdateOtherInventory();
        HideItemInfo();
    }
    public void UpdateOtherInventory()
    {
        for (int i = 0; i < 36; i++)
        {
            if (i+OtherScrol< OtherInvent.Count)
            {
                OtherButtons[i].GetComponent<InventoryBtnController>().SetGameObject(OtherInvent[i+OtherScrol]);
            }
            else
            {
                OtherButtons[i].SetActive(false);
            }
        }
    }
    //обработка нажатия на ячейку в инвентаре
    public void OnClickButton(GameObject GO) {
        if (UI_OtherInventory.activeSelf)
        {
            if (MouseInTop)
            {
                if (GO.GetComponent<Inventory_Item>()._Count == 1 || Input.GetKey(KeyCode.LeftAlt))
                {
                    Put(GO);
                    OtherInvent.Remove(GO);
                }
                else
                {
                    GameObject GOclone = Instantiate(GO,GO.transform.parent);
                    GO.GetComponent<Inventory_Item>()._Count--;
                    GOclone.GetComponent<Inventory_Item>()._Count = 1;
                    Put(GOclone);
                }
            }
            else
            {
                if (GO.GetComponent<Inventory_Item>()._Count == 1 || Input.GetKey(KeyCode.LeftAlt))
                {
                    Put(GO, OtherInvent);
                    ThisInventory.Remove(GO);
                }
                else
                {
                    GameObject GOclone = Instantiate(GO, GO.transform.parent);
                    GO.GetComponent<Inventory_Item>()._Count--;
                    GOclone.GetComponent<Inventory_Item>()._Count = 1;
                    Put(GOclone, OtherInvent);
                }
            }
            GO.GetComponent<Inventory_Item>().OnReplace();
            UpdateOtherInventory();
           // UpdateUI_Inventory();
        }
        else
        {
            GO.GetComponent<Inventory_Item>().OnUse();
            //if (GO.GetComponent<Inventory_Item>() is Weapon) weapon_controller.UpdateUI(Weapon_Panel);
        }
    }
    public void ShowItemImage(GameObject GO)
    {
        Image_Panel.SetActive(true);
        Sprite _sprite = GO.GetComponent<SpriteRenderer>().sprite;
        Image_Panel.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = _sprite;
    }
    public void ShowItemDiscription(GameObject GO)
    {
        string text = GO.GetComponent<Inventory_Item>().Discription();
        if (text.Length == 0) return;
        Discription_Panel.SetActive(true);
        Discription_Panel.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = text;
    }
    public void ShowItemStats(GameObject GO)
    {
        string[] Stats= GO.GetComponent<Inventory_Item>().Stats();
        if (Stats == null) return;
        Stats_Panel.SetActive(true);
        for(int i = 0; i < 13; i++)
        {
            if (i<Stats.GetLength(0) )
                Stats_Panel.transform.GetChild(i).GetComponent<UnityEngine.UI.Text>().text = Stats[i];
            else
                Stats_Panel.transform.GetChild(i).GetComponent<UnityEngine.UI.Text>().text = "";
        }
    }
    public void ShowItemInfo(GameObject GO)
    {
        ShowItemDiscription(GO);
        ShowItemImage(GO);
        ShowItemStats(GO);
    }
    public void HideItemInfo()
    {
        Discription_Panel.SetActive(false);
        Image_Panel.SetActive(false);
        Stats_Panel.SetActive(false);
    }
    private int NumberByItem(Component CO,List<GameObject>list)
    {
        for(int i = 0; i < list.Count;i++)
        {
            if (list[i].GetComponent<Inventory_Item>().GetType() == CO.GetType()) return i;
        }
        return -1;
    }
    public int CountByItem(System.Type T)
    {
        for (int i = 0; i < ThisInventory.Count; i++)
        {
            if (ThisInventory[i].GetComponent<Inventory_Item>().GetType() == T) {
                return ThisInventory[i].GetComponent<Inventory_Item>()._Count;
            }
        }
        return -1;
    }
    public bool HaveItem(GameObject GO)
    {
        return ThisInventory.Contains(GO);
    }
    private GameObject InitBtn(GameObject _panel,int i,int j,float cellSize)
    {
        GameObject NewButton = Instantiate(ButtonPrefab, _panel.transform);
        NewButton.transform.localPosition = new Vector3(3.5f + (i + 0.5f) * cellSize, -3.5f - (j + 0.5f) * cellSize, 0);
        NewButton.GetComponent<UnityEngine.UI.Image>().preserveAspect = true;
        NewButton.GetComponent<InventoryBtnController>().Owner = this;
        NewButton.AddComponent<InventoryButton>();
        NewButton.GetComponent<InventoryButton>().navigation = new UnityEngine.UI.Navigation();
        NewButton.SetActive(false);
        return NewButton;
    }
    private void InitButtonsOnLabel(ref GameObject[] _buttons,GameObject _panel)
    {
        float cellSize = 49;
        _buttons = new GameObject[36];
        int Number = 0;
        for (int j = 0; j < 3; j++)
            for (int i = 0; i < 12; i++)
            {
                _buttons[Number] = InitBtn(_panel,i,j,cellSize);
                Number++;
            }


    }
    private void InitButtons()
    {
        InitButtonsOnLabel(ref Buttons, UI_ThisInventory);
        InitButtonsOnLabel(ref OtherButtons, UI_OtherInventory);
    }

    void Start ()
    {
        HideItemInfo();
        ThisInventory = new List<GameObject>();
        OtherButtons = new GameObject[36];
        InitButtons();
        //weapon_controller = new TwoHandsWeapon_Controller(gameObject.GetComponent<Animator>());
        Image_Panel.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().preserveAspect = true;
        InitBtn(Weapon_Panel, 0, 0, 44);
        InitBtn(Weapon_Panel, 1, 0, 44);

    }
    //обработка скролинга
    void Update()
    {
        weapon_controller.UpdateUI(Weapon_Panel);
        if(UI_ThisInventory.activeSelf)
        UpdateUI_Inventory();
        if (UI_ThisInventory.activeSelf)
        {
            MouseInTop = Camera.main.ScreenToViewportPoint(Input.mousePosition).y > 0.255;
            if (Input.mouseScrollDelta.y != 0)
            {
                if (MouseInTop && UI_OtherInventory.activeSelf)
                {
                    OtherScrol -= (int)Input.mouseScrollDelta.y * 12;
                    if (OtherScrol >= OtherInvent.Count) OtherScrol = 12 * ((int)(OtherInvent.Count / 12));
                    if (OtherScrol < 0) OtherScrol = 0;
                    UpdateOtherInventory();
                }
                else
                {
                    ThisScrol -= (int)Input.mouseScrollDelta.y * 12;
                    if (ThisScrol >= ThisInventory.Count) ThisScrol = 12 * ((int)(ThisInventory.Count / 12));
                    if (ThisScrol < 0) ThisScrol = 0;
                    UpdateUI_Inventory();
                }
                HideItemInfo();
            }
        }
    }
}
