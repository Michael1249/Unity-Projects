using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour {
    const int sizeX = 400;
    const int sizeY = 260;

    public GameObject Cell;
    public int Rocks;
    public int Bushs;
    [SerializeField]
    Color[] colors;
    byte[,] World = new byte[sizeX,sizeY];
    void Start () {

        for(int x = 0; x < sizeX; x++)
            for(int y = 0; y < sizeY; y++)
            {
                GameObject GO =Instantiate(Cell, this.transform);
                GO.transform.position = new Vector2(x, y);
            }
        for(int i = 0; i < Rocks; i++)CreateByID(1);
        for(int i = 0; i < Bushs; i++)CreateByID(2);
	}
	public void CreateByID(byte ID)
    {
        while (true)
        {
            int x = Random.Range(0, sizeX);
            int y = Random.Range(0, sizeY);
            if (World[x, y] == 0)
            {
                World[x, y] = ID;
                return;
            }
        }
    }
	// Update is called once per frame
	void Update () {
        int i = 0;
        SpriteRenderer[] renderers = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (byte b in World)
        {
          //  renderers[i].color = colors[b];
          //  i++;
        }
	}
}
