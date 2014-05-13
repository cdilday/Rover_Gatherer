using UnityEngine;
using System.Collections;

public class fastForwardButton : MonoBehaviour {
	//public string levelName;
	private Color mouseOverColor = Color.blue;
	private Color originalColor ;
	private GameController gameController;


	void Start () { 
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
	}

	void OnMouseEnter()
	{
		originalColor = gameObject.renderer.material.GetColor ("_Color");
		gameObject.renderer.material.color = mouseOverColor;
		
	}
	
	void OnMouseExit()
	{
		gameObject.renderer.material.color = originalColor;
		
	}
	
	void OnMouseDown() {

		originalColor = Color.red;
		mouseOverColor = Color.red;
		gameController.fastMode = true;
		//Application.LoadLevel(levelName);
	}
	
}
