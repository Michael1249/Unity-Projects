using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 корневой клас для всех интерактивных обьектов
 */
public abstract class Clickable : MonoBehaviour {
    private static GameObject _Player;
    //при тыке предположительно подходим к цели, так что реализация уже сдесь
    void Awake()
    {
        _Player= GameObject.FindGameObjectsWithTag("Player")[0];
    }
    public virtual void OnClick()
    {
        Player().GetComponent<Player_Controller>().Target = this.gameObject;
    }

    //взаимодействие с обьектом
    public abstract void OnInteractive();

    public abstract float InteractiveDistanse();

    public static GameObject Player()
    {
        return _Player;
    }
}
