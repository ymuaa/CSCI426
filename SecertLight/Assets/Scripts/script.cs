using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {
	Transform _cubeTransform;
	int direction;
    public GameObject GameManager;

	// Use this for initialization
	void Start () {
		_cubeTransform = gameObject.GetComponent<Transform>();
		direction =4;
	}
	
	// Update is called once per frame
	void Update () {
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
		if(direction ==1)
		{
			_cubeTransform.Translate(Vector3.up * 1f*Time.deltaTime,Space.Self);
		}
		if(direction ==2)
		{
   			_cubeTransform.Translate(Vector3.down * 1f * Time.deltaTime, Space.Self);
		}
		if(direction ==3)
		{
   			_cubeTransform.Translate(Vector3.left * 1f * Time.deltaTime, Space.Self);
		}
		if (direction ==4)
		{
			_cubeTransform.Translate(Vector3.right * 1f * Time.deltaTime, Space.Self);
		}
		
	}

	void OnCollisionEnter2D(Collision2D aaa) //aaa為自定義碰撞事件
    {    
    	if (aaa.gameObject.tag == "Mirror") //如果aaa碰撞事件的物件名稱是CubeA
        {   
        	if(aaa.gameObject.GetComponent<Mirror>().state==0){
        		if(direction ==4){
        			direction =1;
        			}
        			else if(direction ==1){
        				direction =4;
        			}
        			else if(direction ==2){
        				direction =3;
        			}
        			else if(direction ==3){
        				direction =2;
        			}
        		
        	}
        	if(aaa.gameObject.GetComponent<Mirror>().state==1){
        		if(direction ==4){
        			direction =2;
        			}
        			else if(direction ==2){
        				direction =4;
        			}
        			else if(direction ==1){
        				direction =3;
        			}
        			else if(direction ==3){
        				direction =1;
        			}
        		
        	}
            
        }

        if (aaa.gameObject.tag == "Goal") {
        	Destroy(gameObject);
            GameManager.GetComponent<gameManager>().GameWin();
        }


        
    }


}
