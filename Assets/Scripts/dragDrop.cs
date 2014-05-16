using System.Collections;
using UnityEngine;

class dragDrop : MonoBehaviour {
	public AudioClip dropSound;

	public arrowCounter counter;

	private Color mouseOverColor = Color.blue;
	private Color originalColor ;
	
	public bool dragging = false;
	
	private float distance;
	
	private GameController gameController; //this will allow access to the game controller
	
	void Start()
	{
		GameObject arrowCounterTemp = GameObject.Find ("ArrowCounter");
		if (arrowCounterTemp != null) {
			counter = arrowCounterTemp.GetComponent <arrowCounter>();
		}
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
			//counter updating
			if(transform.GetComponent<arrowScript>().originalPos == transform.position)
			{
				//normal arrows
				if(gameObject.transform.parent.GetComponent <ChangeDirection> ()){
					switch(gameObject.transform.parent.GetComponent <ChangeDirection> ().type)
					{
						case 1:
							counter.UpCount--;
							break;
						case 2:
							counter.DownCount--;
							break;
						case 3:
							counter.LeftCount--;
							break;
						case 4:
							counter.RightCount--;
							break;
					}
				}
				else { //flip arrows
					switch(gameObject.transform.parent.GetComponent <arrowFlip> ().type)
					{
						case 1:
							counter.UpFlipCount--;
							break;
						case 2:
							counter.DownFlipCount--;
							break;
						case 3:
							counter.LeftFlipCount--;
							break;
						case 4:
							counter.RightFlipCount--;
							break;
					}
				}
			}
			distance = Vector3.Distance (transform.position, Camera.main.transform.position);
			dragging = true;
		}
	}

	void OnMouseUp()
	{
		if (gameController.canMoveArrows) {
			Vector3 currentPos = transform.position;
			//playing sound
			if(gameController.playSound)
			{
				audio.PlayOneShot(dropSound);
			}
			//snapping to grid
			float tempx, tempy;
			//returning to the original location on UI

			 

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
			if(currentPos.y > 4.64 || currentPos.y < -5.64 || currentPos.x > 4 || currentPos.x < -8)
			{
				if(gameObject.transform.parent.GetComponent <ChangeDirection> ()){
					int tempType = gameObject.transform.parent.GetComponent <ChangeDirection> ().type;
					tempx = 1;
					tempy = 5.3f;
					switch(tempType)
					{
					case 1: 
						tempx = 1;
						tempy = 5.68f;
						counter.UpCount++;
						break;
					case 2:
						tempx = 1;
						tempy = 5;
						counter.DownCount++;
						break;
					case 3:
						tempx = 2;
						tempy = 5.3f;
						counter.LeftCount++;
						break;
					case 4:	
						tempx = 3;
						tempy = 5.3f;
						counter.RightCount++;
						break;
					}
				}
				else{
					int tempType = gameObject.transform.parent.GetComponent <arrowFlip> ().type;
					tempx = 1;
					tempy = 5.3f;
					switch(tempType)
					{
					case 1: 
						tempx = 4;
						tempy = 5.68f;
						counter.UpFlipCount++;
						break;
					case 2:
						tempx = 4;
						tempy = 5;
						counter.DownFlipCount++;
						break;
					case 3:
						tempx = 5;
						tempy = 5.3f;
						counter.LeftFlipCount++;
						break;
					case 4:	
						tempx = 6;
						tempy = 5.3f;
						counter.RightFlipCount++;
						break;
					}
				}
				gameObject.transform.parent.transform.position = new Vector3(-8.47f + tempx,
				                                                             tempy, 0);
				gameObject.transform.position = new Vector3(-8.47f + tempx, tempy, 0);
			} 
			dragging = false;
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