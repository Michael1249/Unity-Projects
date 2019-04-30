using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SimpleEvent : UnityEngine.Events.UnityEvent { };

public abstract class AbstractController : MonoBehaviour {

    protected BodyController Slave;
    public Stats _stats;
    public GameObject SpawnPoint;
    public virtual void DefoultAtack() { }

  //  public delegate void Dead_Event();
    [SerializeField]
    public SimpleEvent OnDeadEvent;
    [SerializeField]
    public SimpleEvent OnRespawnEvent;
    //protected virtual void Start()
    //{
    //    if(_stats.)
    //}
  
    protected virtual void Update()
    {
            if (_stats.HP <= 0) { OnDead(); }//Debug.Log("Dead"); }
    }
    public virtual void OnDead()
    {
        this.enabled = false;
        if(Slave!=null)
        Slave.Dead();
        if(OnDeadEvent!=null)OnDeadEvent.Invoke();
    }
    public void Respawn()
    {
        enabled = true;
        if (SpawnPoint != null) transform.position = SpawnPoint.transform.position;
        Slave.Respawn();
        if (OnRespawnEvent != null) OnRespawnEvent.Invoke();
    }
    public void DeActive_GO()
    {
        gameObject.SetActive(false);
    }
    public void AfterDead()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
