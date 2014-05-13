using UnityEngine;
using System.Collections;

public class RobotScript : MonoBehaviour {

	//type 1: up
	//type 2: down
	//type 3: left
	//type 4: right
	public int directionType;
	private GameController gameController;
	public AudioSource idleEngine;
	public mineralScript mineral;
	bool soundIsPlaying = false;
	public MoveScript mov;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		mov =  GetComponent<MoveScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameController.planningStage && gameController.playSound && !soundIsPlaying) {
			idleEngine.Play ();
			soundIsPlaying = true;
		}
		if (directionType == 1) { //down
			mov.direction = new Vector2 (0, 1);
		} else if (directionType == 2) { //up
			mov.direction = new Vector2 (0, -1);
		} else if (directionType == 3) { //left
			mov.direction = new Vector2 (-1, 0);
		} else if (directionType == 4) { //right
			mov.direction = new Vector2 (1, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		buildingScript building = otherCollider.gameObject.GetComponent<buildingScript> ();
		if (building != null) {
			building.hasReturned = true;
		}
	}

	void OnDestroy()
	{
		if (mineral != null)
			mineral.isPickUp = 0;
		// Game Over.
		// Don't call other object's function in Ondestroy
		// It will cause a crash if the scene is changing
	}
}
