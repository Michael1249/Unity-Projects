using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderController : MonoBehaviour {

    private float time;
    private float HideTime;
    private float timer=0;
    void Start()
    {
        enabled = false;
    }
    public float Timer
    {
        get
        {
            return timer;
        }
    }

    void Update()
    {
            timer += Time.deltaTime;
            if (Timer < time)
                GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, Timer / time);
            else if (Timer > time && Timer < time + HideTime)
                GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 1);
            else if (Timer < time * 2 + HideTime) GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 1 - (Timer - time - HideTime) / time);
            else {
                enabled = false;
                GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0);
            }
    }
    public void Hide(float _time,float _hideTime)
    {
        time = _time;
        HideTime = _hideTime;
        enabled = true;
        timer = 0;
    }
}
