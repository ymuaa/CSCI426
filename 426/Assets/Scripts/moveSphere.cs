using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSphere : MonoBehaviour {
public Rigidbody rb;

    private float t = 0.0f;
    public bool moving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    	if(moving){
    		rb.useGravity = true;
    		//print("move!!");
        }

        
    }
}
