using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class ChangeDirection : MonoBehaviour
{

	//type 1: up
	//type 2: down
	//type 3: left
	//type 4: right
	private GameController gameController;
	public int type;
	public bool arrowCooldown = false;
	private bool fastMode;
	
	void Start () { 
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
	}
	
	void Update(){
		fastMode = gameController.fastMode;
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a robot?
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null && !gameController.planningStage && !arrowCooldown)
		{
			StartCoroutine(snapToArrow(rob));
		}
	}

	//Keeps rover on the grid while still snapping smoothly
	IEnumerator snapToArrow(RobotScript rob)
	{
		arrowCooldown = true;
		if(fastMode == true)
			yield return new WaitForSeconds (0.01f);
		else
			yield return new WaitForSeconds (0.83f);
		rob.directionType = type;
		if(type == 1)
			rob.mov.direction = new Vector2(0, 1);
		else if(type == 2)
			rob.mov.direction = new Vector2(0, -1);
		else if(type == 3)
			rob.mov.direction = new Vector2(-1, 0);
		else if(type == 4)
			rob.mov.direction = new Vector2(1, 0);
		rob.transform.position = new Vector3(transform.position.x,
		                                     transform.position.y,
		                                     rob.transform.position.z);
		Destroy (gameObject);
		if(fastMode == true)
			yield return new WaitForSeconds (0.01f);
		else
			yield return new WaitForSeconds (0.83f);
		arrowCooldown = false;

	}
}