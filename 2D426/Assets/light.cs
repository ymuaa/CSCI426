using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour {

    public GameObject[] invisible;

    // Use this for initialization
    void Start () {
        /*
        invisible = GameObject.FindGameObjectsWithTag("invisible");

        foreach (GameObject objects in invisible)
        {
            //objects.SetActive(false);
            objects.GetComponent<Renderer>().enabled = false;
            Debug.Log("invisible");
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("update");
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("c_trigger");
        if (collider.tag == "prism")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.SetActive(false);
            Debug.Log("trigger");
        }
        if (this.enabled)
        {
            this.enabled = false;
            //This will fire only the first time this object hits a trigger
        }
    }
}
