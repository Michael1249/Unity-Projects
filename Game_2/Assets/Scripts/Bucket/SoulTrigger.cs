using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulTrigger : MonoBehaviour {

    public GameObject Soul_ball;
    public int Count;
	void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"|| other.tag == "Warior")
        {
            for(int i = 0; i < Count;i++)
            {
                GameObject GO = Instantiate(Soul_ball,other.transform.parent);
                GO.transform.position = transform.position+transform.forward*50;
                Vector2 V = other.transform.position - transform.position;
                GO.transform.eulerAngles= new Vector3(0, 0, Random.Range(-50,50)+Mathf.Atan2(V.y,V.x)+180);
                GO.GetComponent<GravityTargetFly>().target = other.transform;


            }
            Destroy(gameObject);
        }
    }
}
