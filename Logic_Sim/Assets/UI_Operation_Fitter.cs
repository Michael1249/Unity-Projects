using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Operation_Fitter : MonoBehaviour {
    public GameObject NodeInPrefab;
    public GameObject NodeOutPrefab;
    public UnityEngine.UI.Text Name;
    public RectTransform Panel1;
    public RectTransform Panel2;
    public RectTransform Text1;
    public RectTransform Text2;
    private List<GameObject> Nodes;
    void Start()
    {
        //Fit();
        Nodes = new List<GameObject>();
        string[] input = { "a", "b", "a", "b" , "a", "b" };
        string[] output = { "c", "d", "e" };
        Set("Operation", input, output);
    }
    [ContextMenu("Fit")]
    public void Fit()
    {
        float Height=Mathf.Max(Text1.rect.height,Text2.rect.height)+10;
        //Rect rect = ((RectTransform)transform.GetChild(0)).rect;
        //rect.size = new Vector2(((RectTransform)transform.GetChild(0).GetChild(0)).rect.width,Height);
        Panel1.sizeDelta = new Vector2(Text1.rect.width+20, Height)/10;
        Panel2.sizeDelta = new Vector2(Text2.rect.width+20, Height)/10;
        float X1 = 45 + Text1.rect.width + Text2.rect.width;
        float X2 = ((RectTransform)Name.transform).sizeDelta.x;
        if (X2 > X1)
        {
            Panel1.sizeDelta += Vector2.right * (X2 - X1) / 20;
            Panel2.sizeDelta += Vector2.right * (X2 - X1) / 20;
        }
        ((RectTransform)transform).sizeDelta = new Vector2(Mathf.Max(X1,X2), Height+5) / 10;
        //((RectTransform)Nodes[0].transform).rect.Set(0,0,3,3);

    }
    public void Set(string name,string[] input,string[] output)
    {
        Name.text = name;
        foreach (GameObject node in Nodes)
        {
            Destroy(node);
        }
        Nodes.Add(Instantiate<GameObject>(NodeOutPrefab,this.transform));
        ((RectTransform)Nodes[0].transform).SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 1, 3);
        ((RectTransform)Nodes[0].transform).SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, -3.5f, 3);
        insertDown(Nodes[0], output.Length-1,1);
        Nodes.Add(Instantiate<GameObject>(NodeInPrefab, this.transform));
        ((RectTransform)Nodes[output.Length].transform).SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 1, 3);
        ((RectTransform)Nodes[output.Length].transform).SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, -3.5f, 3);
        insertDown(Nodes[output.Length], input.Length - 1,1);

        if (output.Length > 0)
        {
            Text1.GetComponent<UnityEngine.UI.Text>().text = output[0];

            for (int i = 1; i < output.Length; i++)
            {
                Text1.GetComponent<UnityEngine.UI.Text>().text += "\n" + output[i];
            }
        }
        if (input.Length > 0)
        {
            Text2.GetComponent<UnityEngine.UI.Text>().text = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                Text2.GetComponent<UnityEngine.UI.Text>().text += "\n" + input[i];
            }
        }
        Fit();
    }
    private void insertDown(GameObject Prefab,int num,int iter)
    {
        if (num == 0) return;
        GameObject GO = Instantiate<GameObject>(Prefab, Prefab.transform.parent);
        ((RectTransform)GO.transform).SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,1+3.4f*iter, 3);
        //((RectTransform)GO.transform).SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, 3);
        Nodes.Add(GO);
        insertDown(GO, --num,++iter);
    }
}
