using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTrigger : MonoBehaviour {
    public AI_Controller AI;
	void OnTriggerStay2D(Collider2D other)
    {
      //  AI.OnViewFieldDetect(other);
    }
}
