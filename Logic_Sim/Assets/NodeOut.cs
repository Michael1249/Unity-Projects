using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NodeOut : UnityEngine.UI.Selectable {
    [SerializeField]
    public GameObject TransPrefab;

    private TransitCreator TC;
    private bool down = false;
    private Transit Trans;
    protected override void Start()
    {
        base.Start();
        TC = GameObject.FindGameObjectWithTag("TransitCreator").GetComponent<TransitCreator>();
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        Trans = Instantiate<GameObject>(TransPrefab,transform.parent).GetComponent<Transit>();
        Trans.Out = transform;
        Trans.LineToMouse();
        TC.Create(Trans);
        //Camera.main.ScreenToWorldPoint(Input.mousePosition)
        down = true;
    }
    void Update()
    {
        if (down)
        {
            Trans.LineToMouse();

            if (Input.GetMouseButtonUp(0))
            {
                down = false;

            }
        }
    }
}
