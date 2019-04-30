using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 корневой клас для всех интерактивных обьектов
 */
public abstract class Clickable : MonoBehaviour {
    
    //при тыке предположительно подходим к цели, так что реализация уже сдесь
    public virtual void OnClick()
    {
        Player().GetComponent<Player_Controller>().Target = this.gameObject;
    }

    //взаимодействие с обьектом
    public abstract void OnInteractive();

    public abstract float InteractiveDistanse();

    public GameObject Player()
    {
        //return Saver.Player;
        return GameObject.FindGameObjectWithTag("Player");
    }
}
