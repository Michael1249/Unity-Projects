using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rools:MonoBehaviour {
    [SerializeField]
    public Gradient gradient;
    public float DescreteColour;
    public bool[] Roole_Born;
    public bool[] Roole_Stay;
    public bool Randomize = false;
    void Start()
    {
        if (Randomize)
        {
            Roole_Born = new bool[27];
            Roole_Stay = new bool[27];
            for(int i =0;i<27;i++)
            {
                Roole_Born[i] = Random.value > 0.5;
                Roole_Stay[i] = Random.value > 0.5;
            }
        }
    }
}
