using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
    public float Speed=0.5f;
    public float ScrollSpeed=0.5f;
    private Vector3 LastPos;
    Vector3 MousePos;
    Vector3 MouseVector;
    float Scroll;
    void Update () {
        MousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseVector = transform.position - MousePos;
        Scroll = Mathf.Pow(2, -Input.mouseScrollDelta.y * ScrollSpeed);
        transform.position = MousePos + MouseVector * Scroll;
        Camera.main.orthographicSize *= Scroll;

        if (Input.GetMouseButton(2))
        {
            transform.position -= (Input.mousePosition - LastPos)*Speed*Camera.main.orthographicSize/50;
        }
        LastPos = Input.mousePosition;
	}
}
