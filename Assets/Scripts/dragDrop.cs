using System.Collections;
using UnityEngine;

class dragDrop : MonoBehaviour {
	public AudioClip dropSound;

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
		audio.enabled = true;
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
			//playing sound
			if(gameController.playSound)
			{
				audio.PlayOneShot(dropSound);
			}
			//snapping to grid
			float tempx, tempy;
			//returning to the original location on UI
			if(currentPos.y > 4.64 || currentPos.y < -5.64 || currentPos.x > 4 || currentPos.x < -8)
			{
				tempx = gameObject.transform.parent.GetComponent <ChangeDirection> ().type;
				gameObject.transform.parent.transform.position = new Vector3(-8.47f + tempx,
				                                                             5.3f, 0);
				gameObject.transform.position = new Vector3(-8.47f + tempx, 5.3f, -1);
			} 
			else 
			{
				if(currentPos.x >=0){
					if (currentPos.x % 1f < 0.53f){
						tempx = 0.53f;
					}
					else{
						tempx = -0.47f;
					}
				}
				else{
					if (currentPos.x % 1f > -0.47f ){
						tempx = -0.47f;
					}
					else{
						tempx = 0.53f;
					}
				}
				if(currentPos.y >=0){
						tempy = 0.14f;

				}
				else{
						tempy = 0.14f;
				}
				gameObject.transform.parent.transform.position = new Vector3(Mathf.Round(currentPos.x) + tempx,
				                                                             Mathf.Round(currentPos.y) + tempy,
				                                                             0);
				gameObject.transform.position = new Vector3(Mathf.Round(currentPos.x) + tempx,
                                                             Mathf.Round(currentPos.y) + tempy,
                                                             -1);
			}
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