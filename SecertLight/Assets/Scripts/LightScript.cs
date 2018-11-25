using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {
    Transform _parentTransform;
    double direction = 2;
    public GameObject GameManager;
    private bool istriggered = false;
    public GameObject copy;
    public string currentColor;
    public SpriteRenderer sr;
    public int speed = 1;
    GameObject new1;


    //Color Sellection
    public Color colorBlue;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;

    // Use this for initialization
    void Start () {
        _parentTransform = gameObject.transform.parent.gameObject.GetComponent<Transform>();

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
            _parentTransform.Translate((Vector3.up + Vector3.left).normalized * speed * Time.deltaTime, Space.Self);
        }
        if (direction ==1)
		{
            _parentTransform.Translate(Vector3.up * speed * Time.deltaTime,Space.Self);
        }
        if (direction == 1.5)
        {
            _parentTransform.Translate(((Vector3.up + Vector3.right).normalized) * speed * Time.deltaTime, Space.Self);
        }
        if (direction ==2)
		{
            _parentTransform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
        }
        if (direction == 2.5)
        {
            _parentTransform.Translate(((Vector3.down + Vector3.right).normalized) * speed * Time.deltaTime, Space.Self);
        }
        if (direction ==3)
		{
            _parentTransform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
		}
        if (direction == 3.5)
        {
            _parentTransform.Translate((Vector3.down + Vector3.left).normalized * speed * Time.deltaTime, Space.Self);
        }
        if (direction ==4)
		{
            _parentTransform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        }

        //keep all color same
        if (sr.color == colorPink)
        {
            //new1.GetComponent<Renderer>().material.color = colorPink;
            new1.GetComponent<SpriteRenderer>().color = colorPink;
        }
        else if (sr.color == colorBlue)
        {
            //new1.GetComponent<Renderer>().material.color = colorBlue;
            new1.GetComponent<SpriteRenderer>().color = colorBlue;
        }
        else if (sr.color == colorPurple)
        {
            //new1.GetComponent<Renderer>().material.color = colorPurple;
            new1.GetComponent<SpriteRenderer>().color = colorPurple;
        }
        else
        {
            //new1.GetComponent<Renderer>().material.color = colorYellow;
            new1.GetComponent<SpriteRenderer>().color = colorYellow;
        }


    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Mirror") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (collider.gameObject.GetComponent<Mirror>().state == 0)
            {
                if (direction == 2)
                {
                    direction = 1;
                }
                else if (direction == 1)
                {
                    direction = 2;
                }
                else if (direction == 4)
                {
                    direction = 3;
                }
                else if (direction == 3)
                {
                    direction = 4;
                }

            }
            if (collider.gameObject.GetComponent<Mirror>().state == 1)
            {
                if (direction == 3)
                {
                    direction = 2;
                }
                else if (direction == 2)
                {
                    direction = 3;
                }
                else if (direction == 1)
                {
                    direction = 4;
                }
                else if (direction == 4)
                {
                    direction = 1;
                }

            }

        }

        if (collider.gameObject.tag == "Goal")
        {
            Destroy(gameObject);
            GameManager.GetComponent<gameManager>().GameWin();
        }

        if (collider.gameObject.tag == "Wall")
        {
            print(gameObject.name);
            Destroy(gameObject);
            GameManager.GetComponent<gameManager>().GameObjectCounter--;
            if (GameManager.GetComponent<gameManager>().GameObjectCounter <= 0)
            {
                GameManager.GetComponent<gameManager>().GameOver();
            }

        }

        if (collider.tag == "Prism" || collider.tag == "Prism2")
        {
            if (istriggered == false)
            {
                // do your things here that has to happen once
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                new1 = Instantiate(gameObject.transform.parent.gameObject);
                SpriteRenderer new1SRender = new1.GetComponent<SpriteRenderer>();

                //keep all color same
                if(sr.color == colorPink) {
                    new1SRender.color = colorPink;
                    //new1.GetComponent<Renderer>().material.color = colorPink;
                } else if (sr.color == colorBlue) {
                    new1SRender.color = colorBlue;
                } else if (sr.color == colorPurple) {
                    new1SRender.color = colorPurple;
                } else {
                    new1SRender.color = colorYellow;
                }
                Debug.Log("sr.color: " + sr.color);
                Debug.Log("new1: " + new1.GetComponent<SpriteRenderer>().color);



                double newDirection;
                if (collider.tag == "Prism") {
                    newDirection = direction + 1;
                } else {
                    newDirection = direction - 1;
                }

                if (newDirection > 4)
                    newDirection -= 4;
                new1.transform.GetChild(0).GetComponent<LightScript>().direction = newDirection;
                //Debug.Log(newDirection);

                //direction -= 0.5;
                //if (direction == 0)
                    //direction = 4;

                //Debug.Log(direction);
                istriggered = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                GameManager.GetComponent<gameManager>().GameObjectCounter++;
            } 
        }

        //color checker
        Debug.Log(collider.tag);
        if (collider.tag != currentColor && (collider.tag == "Blue" || collider.tag == "Yellow" || collider.tag == "Pink"|| collider.tag == "Purple")) {
            GameManager.GetComponent<gameManager>().GameOver();
        }

        //color changer
        if (collider.tag == "BlueChanger") {
            sr.color = colorBlue;
            currentColor = "Blue";
            //r.material.color = colorBlue;
            Destroy(collider.gameObject);
        }
        if (collider.tag == "PinkChanger")
        {
            sr.color = colorPink;
            currentColor = "Pink";
            //r.material.color = colorPink;
            Destroy(collider.gameObject);
        }
        if (collider.tag == "YellowChanger")
        {
            sr.color = colorYellow;
            currentColor = "Yellow";
            //r.material.color = colorYellow;
            Destroy(collider.gameObject);
        }
        if (collider.tag == "PurpleChanger")
        {
            sr.color = colorPurple;
            currentColor = "Purple";
            //r.material.color = colorPurple;
            Destroy(collider.gameObject);
        }
        if (collider.tag == "MirrorTrigger")
        {
            //collider.gameObject.GetComponent<MirrorTrigger>().Mirror.transform.Rotate(0, 0, 90);
            collider.gameObject.GetComponent<MirrorTrigger>().Mirror.GetComponent<Mirror>().Rotate();
            
            Destroy(collider.gameObject);
        }


    }

    void OnTriggerExit2D(Collider2D collider)
    {
        print("Exit");
        istriggered = false;
        new1.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }


    void SetRandomColor() {
        int index = Random.Range(0, 4);
        //sindex = 0;
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
