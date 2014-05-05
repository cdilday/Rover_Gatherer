using UnityEngine;

using System.Collections;



//[RequireComponent(typeof(SphereCollider))]



public class clickDrop : MonoBehaviour
{

	private GameController gameController; //this will allow access to the game controller

	void Start()
	{
		//speed = new Vector2(10, speedY);
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	
	void OnMouseDrag()
		
	{
		if (gameController.canMoveArrows) {
			Vector3 point = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			point.z = gameObject.transform.position.z;

			gameObject.transform.position = point;

			Screen.showCursor = false;
		}
	}
	
	
	
	void OnMouseUp()
		
	{
		if (gameController.canMoveArrows) {
			Screen.showCursor = true;
		}
	}

}