using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {
	public int state=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown(){
		transform.Rotate(0, 0, 90);
		if(state==1){
			state=0;
		}
		else{
			state =1;
		}
		
		print("ok");
	}
}
