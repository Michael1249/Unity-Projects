using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour {
    private float timeToLive=0;
	void Update () {
        if (gameObject.activeSelf)
            if (timeToLive < 0)
            {
                gameObject.SetActive(false);
            }
            else
                timeToLive -= Time.deltaTime;
	}
    public void ShowMessage(string message,float time)
    {
        gameObject.SetActive(true);
        timeToLive = time;
        GetComponentInChildren<UnityEngine.UI.Text>().text = message;
    }
}
