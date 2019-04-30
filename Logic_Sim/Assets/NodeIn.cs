using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeIn : UnityEngine.UI.Selectable {

    TransitCreator TC;
    protected override void Start()
    {
        base.Start();
        TC = GameObject.FindGameObjectWithTag("TransitCreator").GetComponent<TransitCreator>();
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        TC.In = transform;
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        TC.In = null;
    }
}
