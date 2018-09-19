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
      void Awake()
     {
         reader = GetComponent<LineRenderer>();
     }
 
     // Use this for initialization
     void Start()
     {
         reader.SetVertexCount(2);//设置顶点
         reader.SetWidth(0.3f, 0.3f); //设置开始和结束的宽
         reader.SetColors(Color.red, Color.yellow); //设置开始和结束的颜色
         reader.SetPosition(0, transform.position);//设置开始坐标
     }

     // Update is called once per frame
     void Update()
    {
    	reader.positionCount=2;
         Ray ray = new Ray (transform.position, direcction);
         if (Physics.Raycast(ray, out hit)) //当射线碰到物体
         {
             reader.SetPosition(1, hit.point);
             if (hit.collider.tag == "Mirrors") {
             	
             	reader.positionCount=3;
             	reader.SetPosition (2, hit.point +  Vector3.Reflect (hit.point-transform.position, hit.normal));
             	Ray ray2 = new Ray (hit.point, Vector3.Reflect (hit.point-transform.position, hit.normal));
             	if (Physics.Raycast(ray2, out hit)) //当射线碰到物体
             	{
             		if (hit.collider.tag == "Receiver") {
             			print("you win!");
             		}
                    if (hit.collider.tag == "filter")
                    {
                        reader.SetWidth(0.2f, 0.2f);
                    }

             	}
             }

         }
         else
         {
             //以下效果相同，
             //reader.SetPosition(1, ray.GetPoint(1000));
             reader.SetPosition(1, ray.direction * 1000 - transform.position);
         }
             }
 }