using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igla_Cascade : MonoBehaviour
{
    public float time = 3;
    private float timer=0;
    //public GameObject SSS;
    public AudioSource sound;
    private Animator Anim;
    private Collider2D col;
    public bool Used = false;
    [SerializeField]
    private List<Igla_Cascade> Next;
    void Start()
    {
        enabled = false;
        Anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (time < timer)
        {
            enabled = false;
            if (sound)
            // Instantiate(SSS, transform);
            sound.Play();
            Anim.Play("Hit");
            if(Next!=null)
            foreach(Igla_Cascade IC in Next)
            {
                    IC.Set();
            }
        }

    }
    public void Hit()
    {
        col.enabled = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Stats>().PhisicalDamag(30);
    }
    public void Set()
    {
        if (!Used)
        {
            Used = true;
            enabled = true;
        }
    }
    public void Add(Igla_Cascade IC)
    {
        foreach (Igla_Cascade Igla in Next)
        {
            if (Igla.Equals(IC)) return;
        }
        Next.Add(IC);
    }
    public void Reset()
    {
        Used = false;
        enabled = false;
        timer = 0;
        col.enabled = false;
        Anim.Play("Idle");
    }
}
