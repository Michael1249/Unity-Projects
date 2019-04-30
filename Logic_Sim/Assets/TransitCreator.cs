using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitCreator : MonoBehaviour {

    public Transit target;
    public Transform In;
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            if (In)
            {
                target.In = In;
                target.UpdateLine();
                enabled = false;
            }
            else if(target) Destroy(target.gameObject);
        }
	}
    public void Create(Transit transit)
    {
        enabled = true;
        target = transit;
    }
}
