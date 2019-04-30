using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour {
    public static int WIDTH = 10;
    public static int HEIGHT = 15;
    public GameController Game;
    // Use this for initialization
	void Start () {
        for (int x = 0; x < 10; x++)
            for (int y = 0; y < 15; y++)
                Set(x, y, new Color(x/10f, y/15f, 0,0));
        
    }
	private Color Get(int i)
    {
        return transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Image>().color;
    }
	public void Set(int x,int y,Color C)
    {
        if (y < 0) return;
        GameObject Temp= transform.GetChild(x+y*10).gameObject;
        Temp.GetComponent<UnityEngine.UI.Image>().color = C;
    }
    public void Set(int i,Color C)
    {
        if (i < 0) return;
        GameObject Temp= transform.GetChild(i).gameObject;
        Temp.GetComponent<UnityEngine.UI.Image>().color = C;
    }
    public void Reset(int x,int y)
    {
        if (y < 0) return;
        GameObject Temp = transform.GetChild(x+y*10).gameObject;
        Temp.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0);
    }
    public void Reset(int i)
    {
        if (i < 0) return;
        GameObject Temp = transform.GetChild(i).gameObject;
        Temp.GetComponent<UnityEngine.UI.Image>().color=new Color(0,0,0,0);
    }
    public bool Detect(int x,int y)
    {
        if (x >= 0 && x < 10)
        {
            if (y < 0)
                return false;
            else if (y < 15)
                return transform.GetChild(x + y * 10).gameObject.GetComponent<UnityEngine.UI.Image>().color.a != 0;
        }
        return true;
    }
    public void UpdateField()
    {
        Game.NewTetramino();
        while (CheckLine()) ;
        for (int i = 0; i < 10; i++)
            if (Get(i).a != 0) Game.GameOver();
    }
    private bool CheckLine()
    {
        for (int y = 0; y < 15; y++)
        {
            bool flag = true;
            for (int x = 0; x < 10; x++)
                if (transform.GetChild(x + y * 10).gameObject.GetComponent<UnityEngine.UI.Image>().color.a == 0) flag=false;

            if (!flag) continue;
            for (int i = y * 10 + 9; i >9 ; i--)
            {
                Set(i, Get(i - 10));
            }
            for (int i = 0; i < 10; i++) Set(i, new Color(0, 0, 0, 0));
            return true;
        }
        return false;
    }
}
