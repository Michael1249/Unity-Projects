using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : Clickable
{
    [SerializeField]
    private Sprite Sprite_On;
    [SerializeField]
    private Sprite Sprite_Off;
    [SerializeField]
    private bool toggle = false;
    [SerializeField]
    private float CoolDown = 0.5f;
    public SimpleEvent On_Change;
    public SimpleEvent On_Down;
    public SimpleEvent On_Up;
    private float time;
    private bool State = false;
    void Start()
    {
        enabled = false;
    }
    public override float InteractiveDistanse()
    {
        return 0.9f;
    }

    public override void OnInteractive()
    {
        if (!enabled)
        {
            enabled = true;
            if (toggle) SetSprite(!State);
            else
            {
                SetSprite(true);
            }
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > CoolDown)
        {
            enabled = false;
            time = 0;
            if (!toggle) SetSprite(false);
        }
    }
    private void SetSprite(bool flag)
    {
        if (On_Change != null) On_Change.Invoke();
        if (flag) { if (On_Down != null) On_Down.Invoke(); }
        else if (On_Up != null) On_Up.Invoke();
        State = flag;
        if (flag) GetComponent<SpriteRenderer>().sprite = Sprite_On;
        else GetComponent<SpriteRenderer>().sprite = Sprite_Off;
    }
}
