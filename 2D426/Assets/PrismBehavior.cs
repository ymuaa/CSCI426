using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismBehavior : MonoBehaviour {

    public bool flag;

	// Use this for initialization
	void Start () {
        flag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(flag == true)
        {
            foreach (Transform child in transform)
            {
                //child is your child transform
                //child.gameObject.SetActive(true);
                child.gameObject.GetComponent<Renderer>().enabled = false;
                Debug.Log("active");
            }
            Debug.Log("finish");
            flag = false;
        }

	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "light")
        {
            Debug.Log("prism trigger");
            Debug.Log(transform.childCount);
            foreach (Transform child in transform)
            {
                //child is your child transform
                //child.gameObject.SetActive(true);
                child.gameObject.GetComponent<Renderer>().enabled = true;
                Debug.Log("active");
            }
        }
    }
}
