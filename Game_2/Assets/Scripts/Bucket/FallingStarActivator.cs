using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStarActivator : MonoBehaviour {

    public GameObject StarSprite;
	public void ActivateStar()
    {
        StarSprite.transform.parent.transform.position = new Vector3(Random.Range(-5, 12), Random.Range(2, 6), 0);
        StarSprite.GetComponent<Animator>().Play("Fall");
    }
}
