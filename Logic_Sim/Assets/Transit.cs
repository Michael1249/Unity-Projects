using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transit : MonoBehaviour {

    public Transform Out;
    public Transform In;
    LineRenderer LR;
    public float Devidor = 14;
    public float Power = 5.3f;
    void Awake()
    {
        LR = GetComponent<LineRenderer>();
    }
	public void UpdateLine () {
        //LR.SetPosition(0, Out.position);
        //LR.SetPosition(1, In.position);
        UpdateLinePositioms(Out.position, In.position);
        transform.position = (Out.position + In.position) / 2;
	}
    public void LineToMouse()
    {
        Vector3 pos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //LR.SetPosition(0, Out.position);
        //LR.SetPosition(1,pos);
        UpdateLinePositioms(Out.position, pos);
        transform.position = (Out.position + pos) / 2;
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    private void UpdateLinePositioms(Vector2 P1, Vector2 P2)
    {
        Vector3 Point=new Vector3();

       for(int i = 0; i < 40; i++)
        {
            int j = 39 - i;
            Point = ((P2+Vector2.right*Mathf.Pow(j/Devidor,Power)) * i + (P1+Vector2.left*Mathf.Pow(i/Devidor, Power)) * j) / (39);
            LR.SetPosition(i, Point);
        }
    }
}
