using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour {	
	//отображение fps
    //переписать с фильтром
	void Update (){
        this.GetComponent<UnityEngine.UI.Text>().text = "FPS: "+((float)(1/Time.deltaTime)).ToString();
    }
}
