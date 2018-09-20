using UnityEngine;
using System.Collections;
 
public class TouchMove : MonoBehaviour {

	public Camera m_CameraTwo;
     
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(OnMouseDown());
    }
 
    IEnumerator OnMouseDown()
    {
        
        Vector3 screenSpace = m_CameraTwo.WorldToScreenPoint(transform.position);
       
        Vector3 offset = transform.position - m_CameraTwo.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        while (Input.GetMouseButton(0))
        {
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
    
            Vector3 curPosition = m_CameraTwo.ScreenToWorldPoint(curScreenSpace) + offset;
        
            transform.position = curPosition;
            yield return new WaitForFixedUpdate(); 
        }
    }
}