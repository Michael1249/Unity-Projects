using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public GameObject Cell;
    public int SizeX;
    public int SizeY;
    public int SizeZ;
	void Start () {
        //GameObject GO = Instantiate<GameObject>(Cell, transform);
        //GO.transform.position = new Vector3(0, 0, 0);
        //GameObject GO1 = Instantiate<GameObject>(Cell, transform);
        //GO1.transform.position = new Vector3(1, 0, 0);
        //GO.GetComponent<Cell_Fast>().Change.AddListener(GO1.GetComponent<Cell_Fast>().Call);
        //GO1.GetComponent<Cell_Fast>().Change.AddListener(GO.GetComponent<Cell_Fast>().Call);
        //GO1.GetComponent<Cell_Fast>().StartSet(false);
        //GO1.GetComponent<Cell_Fast>().StartSet(true);
        Cell_Fast[,,] Matrix = new Cell_Fast[SizeX*2+1,SizeY * 2+1,SizeZ * 2+1];
        for (int x =0; x < SizeX*2 + 1; x++)
            for (int y =0; y < SizeY*2 + 1; y++)
                for (int z =0; z < SizeZ*2 + 1; z++)
                {
                    GameObject GO = Instantiate<GameObject>(Cell, transform);
                    GO.transform.position = new Vector3(x-SizeX, y-SizeY, z-SizeZ);
                    Matrix[x, y, z] = GO.GetComponent<Cell_Fast>();
                }
        int counter = 0;
        for (int x = 0; x < SizeX * 2 + 1; x++)
            for (int y = 0; y < SizeY * 2 + 1; y++)
                for (int z = 0; z < SizeZ * 2 + 1; z++)
                {
                    for (int x1 = -1; x1 < 2; x1++)
                        for (int y1 = -1; y1 <2 ; y1++)
                            for (int z1 = -1; z1 < 2 ; z1++)
                            {
                                if (x + x1 >= 0 && x + x1 < SizeX * 2 + 1 &&
                                    y + y1 >= 0 && y + y1 < SizeY * 2 + 1 &&
                                    z + z1 >= 0 && z + z1 < SizeZ * 2 + 1 &&
                                    !(x1 == 0 && y1 == 0 && z1 == 0))
                                {
                                    counter++;
                                    Matrix[x, y, z].Change.AddListener(Matrix[x + x1, y + y1, z +z1].Call);
                                    //Matrix[x, y, z].Member.Add(Matrix[x + x1, y + y1, z + z1].gameObject);
                                }
                            }
                    Matrix[x, y, z].StartSet(Mathf.Pow(x-SizeX,2)+ Mathf.Pow(y - SizeY, 2)+ Mathf.Pow(z - SizeZ, 2)<3);
                    //Matrix[x, y, z].StartSet(Random.value>0.5);
                }
    }
}
