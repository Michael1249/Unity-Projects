using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DialogController : MonoBehaviour {
    [HideInInspector]
    public DialogController controller;
    public void Call(int num)
    {
        controller.NextReplica(num);
    } 
}
