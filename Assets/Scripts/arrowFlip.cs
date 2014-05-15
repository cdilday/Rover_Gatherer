using UnityEngine;
using System.Collections;

public class arrowFlip : MonoBehaviour {


	//type 1: up
	//type 2: down
	//type 3: left
	//type 4: right
	//private float zAxis;
	private GameController gameController;
	public int type;
	public bool arrowCooldown = false;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//zAxis = this.transform.rotation.z;
	}
	

	
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a robot?
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null && !gameController.planningStage && !arrowCooldown)
		{
			arrowCooldown = true;
			StartCoroutine(snapToArrow(rob));
		}
	}
	
	//Keeps rover on the grid while still snapping smoothly
	IEnumerator snapToArrow(RobotScript rob)
	{
		if(gameController.fastMode == true)
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
		if(gameController.fastMode == true)
			yield return new WaitForSeconds (0.01f);
		else
			yield return new WaitForSeconds (0.83f);
		if(type == 1 || type == 2)
			this.transform.Rotate (Vector3.right,180);
		if(type == 3 || type == 4)
			this.transform.Rotate (Vector3.up,180);
		//new Quaternion(
		if(type == 1 || type == 3)
			type++;
		else if(type ==2 || type == 4)
			type--;
		arrowCooldown = false;

	}


}
