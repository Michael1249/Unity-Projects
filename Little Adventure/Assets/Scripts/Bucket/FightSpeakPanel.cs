using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSpeakPanel : MonoBehaviour {

    [SerializeField]
    [HideInInspector]
    private bool _fight=false;
    public UnityEngine.UI.Image Image;
    public Sprite Speak;
    public Sprite Fight;
    void Start()
    {
        Set(_fight);
    }
    public void Set(bool f)
    {
        _fight = f;
        Image.sprite = f ? Fight : Speak;
    }
}
