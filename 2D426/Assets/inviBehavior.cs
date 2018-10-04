using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inviBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("ivc_trigger");
        if (collider.tag == "button")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.SetActive(false);
            PrismBehavior myParent = transform.parent.GetComponent<PrismBehavior>();
            myParent.flag = true;
            Debug.Log("ivtrigger");
        }
        
    }
}
