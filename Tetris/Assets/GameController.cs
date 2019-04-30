using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public CellController Field;
    public CellController TempField;
    public GameObject TetraminoPrefab;
    public UnityEngine.UI.Text ScoreBox;
    private Tetramino tetramino;
    private double lvl = 1;
    private int score = -10;
    private int type;
    private Color C;
	public void NewTetramino()
    {
        score += 10;
        ScoreBox.text = "Score: " + score;
        tetramino= Instantiate<GameObject>(TetraminoPrefab).GetComponent<Tetramino>();
        tetramino.Init(Field, type, C,lvl);
        Init();
        lvl *= 0.93;
    }
    
    public void Down()
    {
        tetramino.Down();
    }
    public void Move(int k)
    {
        tetramino.Move(k);
    }
    public void Rotate(int k)
    {
        tetramino.Rotate(k);
    }
    public void GameOver()
    {
        Application.LoadLevel("Menu");
    }
    void Init()
    {
        type=(int)(Random.value*6);
        Vector3 V = new Vector3(Random.value, Random.value, Random.value);
        V.Normalize();
        V *= 2;
        C = new Color(V.x,V.y,V.z);
        for(int i = 0; i < 16; i++)
        {
            TempField.Set(i, new Color(0, 0, 0, 0));
        }
        for (int i = 0; i < 4; i++)
        {
            int x = (int)(1.5f + Tetramino.TetraForms.data[type, i].x);
            int y = (int)(1.5f + Tetramino.TetraForms.data[type, i].y);

            TempField.Set(x+y*4, C);
        }
    }
    // Use this for initialization
	void Start () {
        Init();
        NewTetramino();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
