using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision aaa) //aaa為自定義碰撞事件
    {    
        if (aaa.gameObject.name == "CubeA") //如果aaa碰撞事件的物件名稱是CubeA
        {    
            print("OK"); //在除錯視窗中顯示OK
        }
    }
}
