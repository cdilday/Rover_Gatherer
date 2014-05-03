using System.Collections;

using UnityEngine;



class dragDrop : MonoBehaviour
	
{
	//
	private Color mouseOverColor = Color.blue;
	
	private Color originalColor ;
	
	private bool dragging = false;
	
	private float distance;
	
	
	
	
	
	void OnMouseEnter()

	{
		originalColor = gameObject.transform.parent.renderer.material.GetColor ("_Color");
		gameObject.transform.parent.renderer.material.color = mouseOverColor;
		
	}
	
	
	
	void OnMouseExit()
		
	{
		
		gameObject.transform.parent.renderer.material.color = originalColor;
		
	}
	
	

	void OnMouseDown()
		
	{
		
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		
		dragging = true;
		
	}
	
	
	
	void OnMouseUp()
		
	{
		
		dragging = false;
		
	}
	
	
	
	void Update()
		
	{
		
		if (dragging)
			
		{
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			Vector3 rayPoint = ray.GetPoint(distance);
			
			transform.parent.position = rayPoint;
			transform.position = rayPoint;

		}
		
	}
	
}