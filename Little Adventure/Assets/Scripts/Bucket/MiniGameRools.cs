using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameRools : MonoBehaviour {

    public GateGroup[] rooms;
    private bool[,] rools = {
        {
         false,false,true,
         false,true,false,
         true,false,true
        },
        {
         false,false,false,
         false,false,false,
         true,true,true
        },
        {
         true,false,false,
         false,true,false,
         true,false,true
        },
        {
         false,false,true,
         false,false,true,
         false,false,true
        },
        {
         true,false,true,
         false,false,false,
         true,false,true
        },
        {
         true,false,false,
         true,false,false,
         true,false,false
        },
        {
         true,false,true,
         false,true,false,
         false,false,true
        },
        {
         true,true,true,
         false,false,false,
         false,false,false
        },
        {
         false,false,true,
         false,true,false,
         true,false,false
        }
    };
    public void Call(int num)
    {
        for(int i = 0; i < 9; i++)
        {
            if (rools[num, i]) rooms[i].ReSet();
        }
    }
}
