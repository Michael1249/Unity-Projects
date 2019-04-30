using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 сундук
 храник лист итемов и открывает UI при взаимодействии
 */
public class Chest : Clickable {
    public List<GameObject> Invent;
    public GameObject Key;
    public MessageController MessageBox;
    public override float InteractiveDistanse()
    {
        return 0.8f;
    }

    public override void OnInteractive()
    {
        if (Key)
            if (!Player().GetComponent<Inventory>().HaveItem(Key))
            {
                MessageBox.ShowMessage("Нет нужного ключа", 3);
                return;
            }
            else
            {
                Player().GetComponent<Inventory>().TakeOne(Key);
                Destroy(Key);
                GetComponentInChildren<Collider2D>().enabled = true;
            }
        Player().GetComponent<Player_Controller>().ShowInventoryWithOther(Invent);
    }
    void Start()
    {
        foreach(GameObject GO in Invent)
        {
            GO.SetActive(false);
        }
    }
    void Update()
    {
        GetComponent<Animator>().SetBool("Full", Invent.Count != 0);
    }
	
}
