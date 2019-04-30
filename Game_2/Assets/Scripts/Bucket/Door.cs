using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Clickable
{
    public GameObject Open;
    public GameObject Close;
    public GameObject Key;
    public MessageController MessageBox;
    void Start()
    {
        Set(false);
    }
    public override float InteractiveDistanse()
    {
        return 0.7f;
    }

    public override void OnInteractive()
    {
        if (Player().GetComponent<Inventory>().TakeOne(Key))
        {
            Destroy(Key);
            Set(true);
        }
        else if (MessageBox)
        {
            MessageBox.ShowMessage("Нет нужного ключа", 3);
        }
    }
    public void Set(bool flag)
    {
        Open.SetActive(flag);
        Close.SetActive(!flag);

    }
}
