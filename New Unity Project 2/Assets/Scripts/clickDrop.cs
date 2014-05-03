using UnityEngine;

using System.Collections;



//[RequireComponent(typeof(SphereCollider))]



public class clickDrop : MonoBehaviour
	
{
	
	void OnMouseDrag()
		
	{
		
		Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		point.z = gameObject.transform.position.z;
		
		gameObject.transform.position = point;
		
		Screen.showCursor = false;
		
	}
	
	
	
	void OnMouseUp()
		
	{
		
		Screen.showCursor = true;
		
	}
	
}