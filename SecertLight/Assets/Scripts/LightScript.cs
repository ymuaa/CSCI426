using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {
	Transform _cubeTransform;
	double direction = 2;
    public GameObject GameManager;
    private bool istriggered = false;
    public GameObject copy;

    // Use this for initialization
    void Start () {
		_cubeTransform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(direction);
        /*if(Input.GetKey(KeyCode.W))
		{
			_cubeTransform.Translate(Vector3.up * 1f*Time.deltaTime,Space.Self);
		}
		if(Input.GetKey(KeyCode.S))
		{
   			_cubeTransform.Translate(Vector3.down * 1f * Time.deltaTime, Space.Self);
		}
		if(Input.GetKey(KeyCode.A))
		{
   			_cubeTransform.Translate(Vector3.left * 1f * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey(KeyCode.D))
		{
			_cubeTransform.Translate(Vector3.right * 1f * Time.deltaTime, Space.Self);
		}*/
        if (direction == 0.5)
        {
            _cubeTransform.Translate((Vector3.up + Vector3.left).normalized * 1f * Time.deltaTime, Space.Self);
        }
        if (direction ==1)
		{
			_cubeTransform.Translate(Vector3.up * 1f*Time.deltaTime,Space.Self);
		}
        if (direction == 1.5)
        {
            _cubeTransform.Translate(((Vector3.up + Vector3.right).normalized) * 1f * Time.deltaTime, Space.Self);
        }
        if (direction ==2)
		{
   			_cubeTransform.Translate(Vector3.right * 1f * Time.deltaTime, Space.Self);
		}
        if (direction == 2.5)
        {
            _cubeTransform.Translate(((Vector3.down + Vector3.right).normalized) * 1f * Time.deltaTime, Space.Self);
        }
        if (direction ==3)
		{
            print("ok!");
   			_cubeTransform.Translate(Vector3.down * 1f * Time.deltaTime, Space.Self);
		}
        if (direction == 3.5)
        {
            _cubeTransform.Translate((Vector3.down + Vector3.left).normalized * 1f * Time.deltaTime, Space.Self);
        }
        if (direction ==4)
		{
			_cubeTransform.Translate(Vector3.left * 1f * Time.deltaTime, Space.Self);
		}
		
	}

	void OnCollisionEnter2D(Collision2D aaa) //aaa為自定義碰撞事件
    {    
    	if (aaa.gameObject.tag == "Mirror") //如果aaa碰撞事件的物件名稱是CubeA
        {   
        	if(aaa.gameObject.GetComponent<Mirror>().state==0){
        		if(direction ==2){
        			direction =1;
        		}
        		else if(direction ==1){
        			direction =2;
        		}
        		else if(direction ==4){
        			direction =3;
        		}
        		else if(direction ==3){
        			direction =4;
        		}

            }
        	if(aaa.gameObject.GetComponent<Mirror>().state==1){
        		if(direction ==3){
        			direction =2;
        		}
        		else if(direction ==2){
        			direction =3;
        		}
        		else if(direction ==1){
        			direction =4;
        		}
        		else if(direction ==4){
        			direction =1;
        		}

            }
            
        }

        if (aaa.gameObject.tag == "Goal") {
        	Destroy(gameObject);
            GameManager.GetComponent<gameManager>().GameWin();
        }


        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Prism")
        {
            if (istriggered == false)
            {
                // do your things here that has to happen once
                GameObject new1 = Instantiate(gameObject);
                double newDirection = direction + 0.5;
                if (newDirection == 4.5)
                    newDirection = 0.5;
                new1.GetComponent<LightScript>().direction = newDirection;
                Debug.Log(newDirection);
                direction -= 0.5;
                if (direction == 0)
                    direction = 4;
                Debug.Log(direction);
                istriggered = true;
                GetComponent<BoxCollider2D>().enabled = false;
            }
            
        }
    }

    void OnTriggerExit(Collider coll)
    {
        istriggered = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }


}
