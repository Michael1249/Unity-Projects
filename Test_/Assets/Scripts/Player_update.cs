using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_update : MonoBehaviour {
    public GameObject player;
    public GameObject Cam;
    public GameObject Bullet;
    public int speed = 5;
    public float Cam_Speed;
    public float Reload_Time;
    private float reload=0;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //мягкое следование камеры
        float dx, dz;
        dx = player.transform.position.x - Cam.transform.position.x;
        dz = player.transform.position.z - Cam.transform.position.z - 8;
        Cam.transform.position += player.transform.forward * Time.deltaTime * dz * Cam_Speed;
        Cam.transform.position += player.transform.right * Time.deltaTime * dx * Cam_Speed;

        //player move
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += player.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position -= player.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position -= player.transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += player.transform.right * speed * Time.deltaTime;
        }
        //проверка на убийство игрока и возможности выстрела
        GameObject[] Enemies;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i=0; i < Enemies.Length; i++)
        {
            if (reload <= 0)
            { float range = Mathf.Sqrt(Mathf.Pow(Enemies[i].transform.position.x - player.transform.position.x, 2) +
                     Mathf.Pow(Enemies[i].transform.position.z - player.transform.position.z, 2));
                if (range < 8)
                {
                    GameObject En = Instantiate(Bullet, player.transform.position, Quaternion.identity);
                    En.GetComponent<Bullet>().target_x = Enemies[i].transform.position.x - player.transform.position.x;
                    En.GetComponent<Bullet>().target_z = Enemies[i].transform.position.z - player.transform.position.z;
                    En.GetComponent<Bullet>().range = range;
                    //перезарядка
                    reload = Reload_Time;
                }
            }
            else
            {
                reload -= Time.deltaTime;
            }
            //умираем
            if (Mathf.Abs(Enemies[i].transform.position.x - player.transform.position.x) < 1 &&
                Mathf.Abs(Enemies[i].transform.position.z - player.transform.position.z) < 1)
            {
                Destroy(player);
            }
        }
    }
}
