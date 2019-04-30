using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Controller : MonoBehaviour {
    [SerializeField]
    private UnityEngine.UI.Text textField;
    [SerializeField]
    private UnityEngine.UI.Image image;
    private Animator _animator;
    //public int Age { set; }
    private bool _status=false;
    public bool Status
    {
        get
        {
            return _status;
        }
    }

    void Start()
    {
        image.preserveAspect = true;
        _animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }
    private void Init()
    {
        Debug.Log("Here");
        gameObject.SetActive(true);
        _animator.Play("Idle");
        _status = true;
    }
    public void StartNote(string message)
    {
        textField.enabled = true;
        textField.text = message;
        image.enabled = false;
        Init();
    }
    public void StartNote(Sprite picture)
    {
        textField.enabled = false;
        image.enabled = true;
        image.sprite = picture;
        Init();
    }
    public void EndNote()
    {
        gameObject.SetActive(false);
    }
    public void EndAnim()
    {
        _animator.Play("End");
        _status = false;
    }
}
