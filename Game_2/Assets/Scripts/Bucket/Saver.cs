using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour {

    private GameObject Save;
    private GameObject Game;
    void Start()
    {
        Game = GameObject.FindGameObjectWithTag("Game");
    }
    public void SetSave()
    {
        Save = Instantiate(Game);
        Save.SetActive(false);
    }
    public void LoadSave()
    {
        if (Save)
        {
            Destroy(Game);
            Game = Save;
            Game.SetActive(true);
        }

    }
}
