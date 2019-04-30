using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
    public float Speed=0.5f;
    public float ScrollSpeed=0.5f;
    private Vector3 LastPos;
    public GameObject BallPrefab;
    public GameObject GravityField;
    Vector3 MousePos;
    Vector3 MouseVector;
    Vector3 BallDir;
    Vector3 BallStart;
    float Scroll;
    void Update () {
        MousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseVector = transform.position - MousePos;
        Scroll = Mathf.Pow(2, -Input.mouseScrollDelta.y * ScrollSpeed);
        transform.position = MousePos + MouseVector * Scroll;
        Camera.main.orthographicSize *= Scroll;
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<LineRenderer>().enabled = true;
            BallStart = MousePos;
        }
        if (Input.GetMouseButton(2))
            transform.position -= (Input.mousePosition - LastPos) * Speed * Camera.main.orthographicSize / 50;
        else if (Input.GetMouseButton(1))
        {
            BallDir -= (Input.mousePosition - LastPos) * Speed;
            GetComponent<LineRenderer>().SetPosition(0, (Vector2)BallStart);
            GetComponent<LineRenderer>().SetPosition(1, (Vector2)MousePos);
        }
        if (Input.GetMouseButtonUp(1))
        {
            GameObject ball = Instantiate(BallPrefab,GravityField.transform);
            ball.transform.position = (Vector2)BallStart;
            ball.GetComponent<Rigidbody2D>().AddForce(BallDir);
            BallDir = Vector3.zero;
            GetComponent<LineRenderer>().enabled = false;
        }
        LastPos = Input.mousePosition;
	}
}
