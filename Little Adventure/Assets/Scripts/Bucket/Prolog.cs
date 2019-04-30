using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prolog : MonoBehaviour {

    public GameObject UI;
    public GameObject Player;
    public PrologMessage Message;
    public GameObject FirstTheme;
    public string[] Messages;
    public float[] Delaies;
    public float[] AlphaDelaies;
    public float[] ShowTimes;
    private int Indx=0;
    private float time = 0;
    public void On()
    {
        FirstTheme.SetActive(false);
        UI.SetActive(false);
        Player.GetComponent<Player_Controller>().CanControl = false;
    }
    public void Off()
    {
        FirstTheme.SetActive(true);
        UI.SetActive(true);
        Player.GetComponent<Player_Controller>().CanControl = true;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Message.gameObject.SetActive(false);
            Off();
            gameObject.SetActive(false);
        }
        if (Indx < Messages.Length)
        {
            time += Time.deltaTime;
            if (time > Delaies[Indx])
            {
                //time -= Delaies[Indx];
                Message.Set(Messages[Indx], ShowTimes[Indx],AlphaDelaies[Indx]);
                Indx++;
            }
        }
    }
}
