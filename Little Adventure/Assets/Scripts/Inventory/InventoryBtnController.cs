using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 контроллер кнопки-ячейки в инвентаре
 промежуточный клас для взаимодействия с инвентарём путём UI
 */
public class InventoryBtnController : MonoBehaviour {

    public GameObject Item;
    public Inventory Owner;
    private const float timeToShow = 0.3f;
    private float time;
    private bool flagClock = false;
    public void OnClick()
    {
        Owner.OnClickButton(Item);
    }
    public void ShowDiscription()
    {
        flagClock = true;
    }
    public void HideDiscription()
    {
        flagClock = false;
        time = 0;
        Owner.HideItemInfo();
    }
    public void SetGameObject(GameObject GO)
    {
        gameObject.SetActive(true);
        Item = GO;
        GetComponent<UnityEngine.UI.Image>().sprite = GO.GetComponent<Inventory_Item>().GetSprite();
        int Count = GO.GetComponent<Inventory_Item>()._Count;
        GetComponentInChildren<UnityEngine.UI.Text>().text = Count != 1 ? Count.ToString() : "";

    }
    public void Update()
    {
        if (flagClock)
            if (time > timeToShow)
            {
                flagClock = false;
                Owner.ShowItemInfo(Item);
            }
            else
                time += Time.deltaTime;
    }
}
