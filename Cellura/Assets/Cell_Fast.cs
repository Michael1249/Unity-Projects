using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Cell_Fast : MonoBehaviour {
    private Rools rools;
    public BoolEvent Change;
    public List<GameObject> Member;
    private bool State=false;
    private ColorController CellColor;
    [SerializeField]
    private int Members=0;
    void Awake () {
        CellColor = GetComponent<ColorController>();
        CellColor.Set(false);
        rools = transform.parent.GetComponent<Rools>();
        Change = new BoolEvent();
	}
    public void StartSet(bool flag)
    {
        if (flag != false)
        {
            CellColor.Set(flag);
            State = flag;
            Change.Invoke(flag);
        }
    }
    private void Set(bool flag)
    {
        CellColor.Set(flag);
        State = flag;
    }
    public void Call(bool flag)
    {
        enabled = true;
        Members += flag ? 1 : -1;
    }
	void Update () {
        if (State)
        {
            if (!rools.Roole_Stay[Members])
            {
                Set(false);
                return;
            }
        }
        else
        {
            if (rools.Roole_Born[Members])
            {
                Set(true);
                return;
            }
        }
        enabled = false;
	}
    void LateUpdate()
    {
        Change.Invoke(State);
    }
}
public class BoolEvent : UnityEvent<bool> { }