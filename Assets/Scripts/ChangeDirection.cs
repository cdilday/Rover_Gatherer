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
	
	void Start () { 
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
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
		yield return new WaitForSeconds (0.8f);
		rob.directionType = type;
		rob.transform.position = new Vector3(transform.position.x,
		                                     transform.position.y,
		                                     rob.transform.position.z);
		Destroy (gameObject);
		yield return new WaitForSeconds (0.83f);
		arrowCooldown = false;

	}
}