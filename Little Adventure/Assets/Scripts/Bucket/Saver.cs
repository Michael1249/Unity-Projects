using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class Saver : MonoBehaviour {

    private GameObject Save;
    private GameObject Game;
    [HideInInspector]
    public static GameObject Player;
    public SimpleEvent OnLoad;
    void Start()
    {
        Game = GameObject.FindGameObjectWithTag("Game");
        Player= GameObject.FindGameObjectWithTag("Player");
    }
    public void SetSave()
    {
        Debug.Log("SetSave");
        if(Save!=null)Destroy(Save);
        Save = Instantiate(Game);
        //Save =ExtensionMethods.DeepClone<GameObject>(Game);
        Save.SetActive(false);
    }
    public void LoadSave()
    {
        if (Save)
        {
            Debug.Log("LoadSave");
            if (OnLoad != null) OnLoad.Invoke();
            Destroy(Game);
            Game = Instantiate(Save);
            Game.SetActive(true);
            Player = Game.GetComponentInChildren<Player_Controller>().gameObject;
        }

    }
    public static T DeepClone<T>(T obj)
    {
        using (var ms = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;

            return (T)formatter.Deserialize(ms);
        }
    }
}

public static class ExtensionMethods
{
    // Deep clone
    public static T DeepClone<T>(this T a)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, a);
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }
    }
}