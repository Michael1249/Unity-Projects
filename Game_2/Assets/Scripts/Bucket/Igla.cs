using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igla : MonoBehaviour {

    private Collider2D other;
    private Animator Anim;
    public GameObject Sound;
    private GameObject temp;
    private bool inTrigger; 
    void Start()
    {
        Anim = GetComponent<Animator>();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (this.other == other) inTrigger = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {if(!Anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        if (other.GetComponent<AbstractController>() != null)
        {
            inTrigger = true;
            this.other = other;
            Anim.Play("Hit");
            //if (temp != null) Destroy(temp);
            temp=Instantiate(Sound, transform);
        }
    }
    public void End()
    {
        Destroy(temp);
    }
    public void Hit()
    {
        if(inTrigger)
        other.GetComponent<Stats>().PhisicalDamag(30);
    }
    public void Play()
    {
        //Sound.Play();
    }
}
