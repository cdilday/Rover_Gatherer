using UnityEngine;
using System.Collections;

public class RobotScript : MonoBehaviour {

	//type 1: up
	//type 2: down
	//type 3: left
	//type 4: right
	public int directionType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveScript mov =  GetComponent<MoveScript>();
		if(directionType == 1)
			mov.direction = new Vector2(0, 1);
		else if(directionType == 2)
			mov.direction = new Vector2(0, -1);
		else if(directionType == 3)
			mov.direction = new Vector2(-1, 0);
		else if(directionType == 4)
			mov.direction = new Vector2(1, 0);
	}

	void OnDestroy()
	{
		// Game Over.
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediately.
		transform.parent.gameObject.AddComponent<gameOverScript>();
	}
}
