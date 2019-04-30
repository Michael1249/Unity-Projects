using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadController : MonoBehaviour
{
    public static int RespawnCost = 1;
 public void StartWindowDead()
    {
     int SoulsCount = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Inventory>().CountByItem(System.Type.GetType("Soul_Item"));
        if (SoulsCount >= RespawnCost)
        {
            GetComponent<Animator>().Play("Dead");
        }
        else
            GetComponent<Animator>().Play("Dead");
        //GetComponent<Animator>().Play("GameOver");
    }
 public void EndWindowDead()
    {
        GetComponent<Animator>().Play("Hide");
    }
}
