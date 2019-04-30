using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Controller : MonoBehaviour {

    public GameObject[] Gates;
    public bool SpawnEnemies = true;
    public GameObject[] Enemies;
    public bool Active = true;
    public SimpleEvent OnStartRoom;
    public SimpleEvent OnEndRoom;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(Active)
        if(other.tag=="Player")
        {
                other.GetComponent<Player_Controller>().ResetWeapon(true);
            foreach (GameObject GO in Gates)
            {
                GO.GetComponent<Animator>().Play("GateOn");
            }
                if (SpawnEnemies)
                    Spawn();
            if (OnStartRoom != null) OnStartRoom.Invoke();
        }
    }
    public void Spawn()
    {
        foreach (GameObject GO in Enemies)
        {
            GO.SetActive(true);
            GO.GetComponent<Animator>().Play("Start");
        }
    }
	public void EnemyDead()
    {
        bool flag = false;
        foreach (GameObject GO in Enemies)
        {
            if (GO.GetComponent<AbstractController>().enabled)
            {
                flag = true;
                return;
            }
        }
        if (!flag)
        {
            foreach (GameObject GO in Gates)
            {
                GO.GetComponent<Animator>().Play("GateOff");
            }
            if (OnEndRoom != null) OnEndRoom.Invoke();
            Active = false;
        }
    }
}
