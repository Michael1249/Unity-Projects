using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTheme : MonoBehaviour {

    private Light Halo;
    float time = 0;
    int nextTheme;
    public ColorThemeBeh[] CT;
    private ColorThemeBeh nowTheme;
    void Start () {
         Halo= GetComponent<Light>();
        nowTheme = new ColorThemeBeh();
        ResetNowTheme();
        Halo.color = CT[0]._Color;
        Halo.intensity = CT[0].Intensity;
    }
    void ResetNowTheme()
    {
        if (Halo)
        {
            nowTheme._Color = Halo.color;
            nowTheme.Intensity = Halo.intensity;
        }
    }
	void Update () {
        time += Time.deltaTime;
        if (time < CT[nextTheme].Delay)
        {
            Halo.color = CT[nextTheme]._Color * time / CT[nextTheme].Delay + nowTheme._Color * (1 - time / CT[nextTheme].Delay);
            Halo.intensity = CT[nextTheme].Intensity * time / CT[nextTheme].Delay + nowTheme.Intensity * (1 - time / CT[nextTheme].Delay);
        }
        else
        {
            nowTheme = CT[nextTheme];
            Halo.color = nowTheme._Color;
            Halo.intensity = nowTheme.Intensity;
            enabled = false;
        }
    }
    public void Set(int num)
    {
        if (enabled) ResetNowTheme();
        //Halo.color = CT[num]._Color;
        //Halo.intensity = CT[num].Intensity;
        nextTheme = num;
        time = 0;
        enabled = true;
    }
}
