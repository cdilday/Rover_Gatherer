using UnityEngine;
using System.Collections;

public class RunButtonScript : MonoBehaviour {

	private GameController gameController;
	public Sprite reset;
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
			this.GetComponent<SpriteRenderer>().sprite = reset;
			this.transform.localScale = new Vector3(1.5f, 1.5f, 1);
		} else {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
