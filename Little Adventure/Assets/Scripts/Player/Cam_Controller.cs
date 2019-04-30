using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Управление движением камеры и установка ограничения фпс
 */
public class Cam_Controller : MonoBehaviour {
    public GameObject target;
    public float Height;
    public float Speed;
	
	// Update is called once per frame
	void Update () {
        transform.position += Speed*(target.transform.position+new Vector3(0,0,-Height)- transform.position);
    }
}
