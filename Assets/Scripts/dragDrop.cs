using System.Collections;

using UnityEngine;



class dragDrop : MonoBehaviour
	
{
	//
	private Color mouseOverColor = Color.blue;
	
	private Color originalColor ;
	
	public bool dragging = false;
	
	private float distance;
	
	private GameController gameController; //this will allow access to the game controller
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	
	void OnMouseEnter()
	{
		if (gameController.canMoveArrows) {
			originalColor = gameObject.transform.parent.renderer.material.GetColor ("_Color");
			gameObject.transform.parent.renderer.material.color = mouseOverColor;
		}
	}
	
	
	
	void OnMouseExit()
		
	{
		if (gameController.canMoveArrows) {
			gameObject.transform.parent.renderer.material.color = originalColor;
		}
	}
	
	

	void OnMouseDown()
		
	{
		if (gameController.canMoveArrows) {
			distance = Vector3.Distance (transform.position, Camera.main.transform.position);
			dragging = true;
		}
	}
	
	
	
	void OnMouseUp()
		
	{
		if (gameController.canMoveArrows) {
			dragging = false;
			Vector3 currentPos = transform.position;
			//snapping to grid
			float temp;
			if(currentPos.x >=0){
				if (currentPos.x % 1f < 0.5f){
					temp = 0.5f;
				}
				else{
					temp = -0.5f;
				}
			}
			else{
				if (currentPos.x % 1f > -0.5f ){
					temp = -0.5f;
				}
				else{
					temp = 0.5f;
				}
			}
			gameObject.transform.parent.transform.position = new Vector3(Mathf.Round(currentPos.x) + temp,
			                                                             Mathf.Round(currentPos.y),
			                                                             currentPos.z);
		}
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