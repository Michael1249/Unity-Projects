using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject explosive;
    public float Boom_Range;
    //координаты цели
    public float target_x;
    public float target_z;
    //растояние до цели
    public float range;
    //скорость снаряда
    public float Vel;
    //ускорение св.под.
    public float g;
    //скорости вдаль осей
    private float vel_x;
    private float vel_z;
    private float vel_y;
    private int step = 3;
    private bool boom = false;

    // Use this for initialization
    void Start () {
        //расчёт угла (навесом)
        float angle =Mathf.PI/2-0.5f*Mathf.Asin(range*g/Mathf.Pow(Vel,2));
        //расчёт скоростей по осям
        vel_y = Mathf.Sin(angle)*Vel;
        vel_x = Mathf.Cos(angle) * Vel*target_x/range;
        vel_z = Mathf.Cos(angle) * Vel * target_z / range;
    }
	
	// Update is called once per frame
	void Update () {
        //move
        this.gameObject.transform.position += gameObject.transform.forward * vel_z * Time.deltaTime;
        this.gameObject.transform.position += gameObject.transform.right * vel_x * Time.deltaTime;
        this.gameObject.transform.position += gameObject.transform.up * vel_y * Time.deltaTime;
        vel_y -= g * Time.deltaTime;

        //проверка на уничтожение бота
        GameObject[] Enemies;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (!boom)
            {
                if (Mathf.Abs(Enemies[i].transform.position.x - this.gameObject.transform.position.x) < 1 &&
                    Mathf.Abs(Enemies[i].transform.position.z - this.gameObject.transform.position.z) < 1 &&
                    Mathf.Abs(Enemies[i].transform.position.y - this.gameObject.transform.position.y) < 1)
                {
                    Destroy(Enemies[i]);
                }
            }else if(Mathf.Sqrt(Mathf.Pow(Enemies[i].transform.position.x - this.gameObject.transform.position.x, 2)+
                Mathf.Pow(Enemies[i].transform.position.z - this.gameObject.transform.position.z, 2)) < Boom_Range)
            {
                Destroy(Enemies[i]);
                boom = false;
            }
        }
        //отскок
        if (this.gameObject.transform.position.y < 0)
        {
            boom = true;
            Instantiate(explosive, this.gameObject.transform.position, new Quaternion(-90, 90, 90, 90));
            vel_y *= -0.7f;
            this.gameObject.transform.position += gameObject.transform.up * vel_y * Time.deltaTime;
            step--;
            if (step == 0) Destroy(this.gameObject);
        }
    }
}
