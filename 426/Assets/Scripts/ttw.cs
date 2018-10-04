using UnityEngine;
 using System.Collections;
  
 public class ttw : MonoBehaviour
  {
      LineRenderer reader;
      RaycastHit hit;
      Ray ray;
      public Camera m_CameraTwo;
      public GameObject EndPoint;
      Vector3  direcction = new Vector3(1.0f, -1.0f, 0.0f);
      public int currentPoint=0 ;
      public Color c1 = Color.white;
    public Color c2 = new Color(1, 1, 1, 0);
      void Awake()
     {
         reader = GetComponent<LineRenderer>();
     }
 
     // Use this for initialization
     void Start()
     {
         reader.SetVertexCount(2);//设置顶点
         reader.SetWidth(0.1f, 0.1f); //设置开始和结束的宽
         reader.SetColors(c1, c2); //设置开始和结束的颜色
         reader.SetPosition(0, transform.position);//设置开始坐标
     }

     // Update is called once per frame
     void Update()
    {
    	reader.positionCount=2;
         Ray ray = new Ray (transform.position, direcction);
         currentPoint=1;
         if (Physics.Raycast(ray, out hit)) //当射线碰到物体
         {
             handleHits();

         }
         else
         {
             //以下效果相同，
             //reader.SetPosition(1, ray.GetPoint(1000));
             reader.SetPosition(1, ray.direction * 1000 - transform.position);
         }
    }

    void handleHits(){
        reader.SetPosition(currentPoint, hit.point);
        if (hit.collider.tag == "Mirrors") {
            reader.positionCount++;
            currentPoint++;
            reader.SetPosition (currentPoint, hit.point +  Vector3.Reflect (hit.point-transform.position, hit.normal));
            Ray ray2 = new Ray (hit.point, Vector3.Reflect (hit.point-transform.position, hit.normal));
            if (Physics.Raycast(ray2, out hit)) //当射线碰到物体
            {
                handleHits();

            }
        }
        if (hit.collider.tag == "Receiver") {
            print("you win!");
        }
        if (hit.collider.tag == "Rope") {
            hit.collider.gameObject.GetComponent<DropSphere>().Sphere.GetComponent<moveSphere>().moving=true;
            hit.collider.gameObject.SetActive(false);
        }
    }
 }