using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_move : MonoBehaviour {
    private float angle;//направление движения бота
    public float Speed;//скорость
	// Use this for initialization
	void Start () {
        angle = Random.Range(0, Mathf.PI * 2);
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * Mathf.Sin(angle)*Speed;
        this.gameObject.transform.position += this.gameObject.transform.right * Time.deltaTime * Mathf.Cos(angle)*Speed;
        angle += Random.Range(-0.3f, 0.3f);
        //двигаем бота и рандомно меняем угол
    }
}
