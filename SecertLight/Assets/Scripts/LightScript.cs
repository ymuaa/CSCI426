using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {
	Transform _cubeTransform;
	double direction = 2;
    public GameObject GameManager;
    private bool istriggered = false;
    public GameObject copy;
    public string currentColor;
    public SpriteRenderer sr;
    public int speed = 1;
    

    //Color Sellection
    public Color colorBlue;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;

    // Use this for initialization
    void Start () {
		_cubeTransform = gameObject.GetComponent<Transform>();

        //set color
        SetRandomColor();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(direction);
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
            _cubeTransform.Translate((Vector3.up + Vector3.left).normalized * speed * Time.deltaTime, Space.Self);
        }
        if (direction ==1)
		{
			_cubeTransform.Translate(Vector3.up * speed * Time.deltaTime,Space.Self);
		}
        if (direction == 1.5)
        {
            _cubeTransform.Translate(((Vector3.up + Vector3.right).normalized) * speed * Time.deltaTime, Space.Self);
        }
        if (direction ==2)
		{
   			_cubeTransform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
		}
        if (direction == 2.5)
        {
            _cubeTransform.Translate(((Vector3.down + Vector3.right).normalized) * speed * Time.deltaTime, Space.Self);
        }
        if (direction ==3)
		{
            
<<<<<<< HEAD
   			_cubeTransform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
=======
   			_cubeTransform.Translate(Vector3.down * 1f * Time.deltaTime, Space.Self);
>>>>>>> c6374199e84ba704af34d2177c3b5895a5e60130
		}
        if (direction == 3.5)
        {
            _cubeTransform.Translate((Vector3.down + Vector3.left).normalized * speed * Time.deltaTime, Space.Self);
        }
        if (direction ==4)
		{
			_cubeTransform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
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

        if (aaa.gameObject.tag == "Wall")
        {
            print(gameObject.name);
            Destroy(gameObject);
            GameManager.GetComponent<gameManager>().GameObjectCounter--;
            if(GameManager.GetComponent<gameManager>().GameObjectCounter<=0){
                GameManager.GetComponent<gameManager>().GameOver();
            }
            
        }


        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Prism" || collider.tag == "Prism2")
        {
            if (istriggered == false)
            {
                // do your things here that has to happen once
                GameObject new1 = Instantiate(gameObject);

                //hard code color
                GetComponent<SpriteRenderer>().color = colorPink;

                double newDirection;
                if (collider.tag == "Prism") {
                    newDirection = direction + 1;
                } else {
                    newDirection = direction - 1;
                }

                if (newDirection > 4)
                    newDirection -= 4;
                new1.GetComponent<LightScript>().direction = newDirection;
                //Debug.Log(newDirection);
<<<<<<< HEAD

                //direction -= 0.5;
                //if (direction == 0)
                    //direction = 4;

=======
                direction -= 0.5;
                if (direction == 0)
                    direction = 4;
>>>>>>> c6374199e84ba704af34d2177c3b5895a5e60130
                //Debug.Log(direction);
                istriggered = true;
                //GetComponent<BoxCollider2D>().enabled = false;
                GameManager.GetComponent<gameManager>().GameObjectCounter++;
            } 
        }

        //color checker
        //Debug.Log(collider.tag);
<<<<<<< HEAD
        //if (collider.tag != currentColor && (collider.tag == "Blue" || collider.tag == "Yellow" || collider.tag == "Pink"|| collider.tag == "Purple")) {
        //    GameManager.GetComponent<gameManager>().GameOver();
        //}
=======
        if (collider.tag != currentColor && (collider.tag == "Blue" || collider.tag == "Yellow" || collider.tag == "Pink"|| collider.tag == "Purple")) {
            GameManager.GetComponent<gameManager>().GameOver();
        }
>>>>>>> c6374199e84ba704af34d2177c3b5895a5e60130

        //color changer
        if (collider.tag == "BlueChanger") {
            sr.color = colorBlue;
            Destroy(collider.gameObject);
        }
        if (collider.tag == "PinkChanger")
        {
            sr.color = colorPink;
            Destroy(collider.gameObject);
        }
        if (collider.tag == "YellowChanger")
        {
            sr.color = colorYellow;
            Destroy(collider.gameObject);
        }
        if (collider.tag == "PurpleChanger")
        {
            sr.color = colorPurple;
            Destroy(collider.gameObject);
        }
        if (collider.tag == "MirrorTrigger")
        {
            //collider.gameObject.GetComponent<MirrorTrigger>().Mirror.transform.Rotate(0, 0, 90);
            collider.gameObject.GetComponent<MirrorTrigger>().Mirror.GetComponent<Mirror>().Rotate();
            
            Destroy(collider.gameObject);
        }


    }

    void OnTriggerExit(Collider coll)
    {
        print("Exit");
        istriggered = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }


    void SetRandomColor() {
        int index = Random.Range(0, 4);
        index = 2;
        switch(index) {
            case 0:
                currentColor = "Blue";
                sr.color = colorBlue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
            case 3:
                currentColor = "Purplr";
                sr.color = colorPurple;
                break;
        }
    }
}
