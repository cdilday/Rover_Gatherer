using UnityEngine;
using System.Collections;

public class RunButtonScript : MonoBehaviour {

	private GameController gameController;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	
	void OnMouseDown()
	{
		if (gameController.planningStage) {
			gameController.planningStage = false; 
			gameController.canMoveArrows = false;
			gameController.startCount = true;
		} else {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
