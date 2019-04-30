using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Game : MonoBehaviour {
    public GameObject prefab_flat;
    public GameObject prefab_enemy;
    
    public ArrayList Enemies;
    // Use this for initialization
    void Start () {
        /*
        замащаю плоскость текстурками и ботами
        p.s. знаю что можно проще но пока не разобрался
        overwrite
        */
        for (int z = -5; z < 5; z++)
        {
            for (int x = -5; x < 5; x++)
            {
                Vector3 pos = new Vector3(x*20,-1,z*20);
                Vector3 en_pos = new Vector3(Random.Range(0,20), 1, Random.Range(0, 20));
                Instantiate(prefab_flat, pos, Quaternion.identity);
                Instantiate(prefab_enemy, pos+en_pos, Quaternion.identity);
            }
        }
    }
	
}
