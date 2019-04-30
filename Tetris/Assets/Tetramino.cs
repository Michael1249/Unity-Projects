using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Tetras { I, J, L, O, S, T, Z };
public class Tetramino : MonoBehaviour {
    public static class TetraForms
    {
        public class XY
        {
            public double x;
            public double y;
            public XY(double a,double b){ x = a;y = b; }
        }
        public static readonly XY[,] data=new XY[7, 4] { 
            {new XY(-1.5f,0),new XY(-0.5f,0),new XY(0.5f,0),new XY(1.5f,0) },//I
            {new XY(0.5f,1f),new XY(0.5f,0),new XY(0.5f,-1),new XY(-0.5f,-1) },//J
            {new XY(-0.5f,1f),new XY(-0.5f,0),new XY(-0.5f,-1),new XY(0.5f,-1) },//L
            {new XY(-0.5f,-0.5f),new XY(-0.5f,0.5f),new XY(0.5f,-0.5f),new XY(0.5f,0.5f) },//O
            {new XY(1,0.5f),new XY(0,0.5f),new XY(0,-0.5f),new XY(-1,-0.5f) },//S
            {new XY(-1,0),new XY(0,0),new XY(1,0),new XY(0,1) },//T
            {new XY(-1,0.5f),new XY(0,0.5f),new XY(0,-0.5f),new XY(1,-0.5f)} //Z
        };

        
    }
    public CellController Field;
    public double timer;
    private double LVL;
    TetraForms.XY[] form;
    TetraForms.XY Pos;
    public Color C;
    public int type;
    public void Init(CellController f,int T,Color c,double lvl,double x=4.5f,double y=-1)
    {
        LVL = lvl;
        Field = f;
        C = c;
        type = T;
        form = new TetraForms.XY[4];
        form[0] = TetraForms.data[T, 0]; 
        form[1] = TetraForms.data[T, 1]; 
        form[2] = TetraForms.data[T, 2]; 
        form[3] = TetraForms.data[T, 3];
        timer = 0;
        Pos = new TetraForms.XY(x,y);
    }
    private TetraForms.XY[] Rotated(int k)
    {
        TetraForms.XY[] res = new TetraForms.XY[4];
        for(int i = 0; i < 4; i++)
        {
            res[i] = new TetraForms.XY(form[i].y * k, -form[i].x * k);
        }
        return res;
    }
    public void Move(int k)
    {
        Clear();
        for (int i = 0; i < 4; i++)
        {
            if (Field.Detect((int)(0.5f +k+ Pos.x + form[i].x), (int)(0.5f + Pos.y + form[i].y)))
            {
                Draw();
                return;
            }
        }
        Pos.x += k;
        Draw();
    }
    public void Rotate(int k)
    {
        TetraForms.XY[] temp = Rotated(k);
        Clear();
        for (int i = 0; i < 4; i++)
        {
            if (Field.Detect((int)(0.5f + Pos.x + temp[i].x), (int)(0.5f + Pos.y + temp[i].y)))
            {
                Draw();
                return;
            }
        }
        form = temp;
        Draw();
    }
    public void Down() { LVL = 0; }
    void Update () {
        timer += Time.deltaTime;
        if (timer > LVL)
        {
            timer -= LVL;
            Clear();
            for (int i = 0; i < 4; i++)
            {
                if (Field.Detect((int)(0.5f + Pos.x + form[i].x), (int)(1.5f + Pos.y + form[i].y)))
                {
                    Draw();
                    Destroy(this.gameObject);
                    Field.UpdateField();
                    return;
                }
            }
            Pos.y += 1;
            Draw();
        }
	}
    public void Clear()
    {
        for (int i = 0; i < 4; i++)
        {
            Field.Reset((int)(0.5f + Pos.x + form[i].x), (int)(0.5f + Pos.y + form[i].y));
        }
    }
    public void Draw()
    {
        for (int i = 0; i < 4; i++)
        {
            Field.Set((int)(0.5f + Pos.x + form[i].x), (int)(0.5f + Pos.y + form[i].y), C);
        }
    }
}
