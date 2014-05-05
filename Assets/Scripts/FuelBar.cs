using UnityEngine;
using System.Collections;

public class FuelBar : MonoBehaviour {
	public float barDisplay; //current progress
	public float decay;
	public Vector2 pos = new Vector2(100,0);
	public Vector2 size = new Vector2(20,20);
	public Texture2D emptyTex;
	public Texture2D fullTex;

	private GameController gameController;

	void Start()
	{
		//speed = new Vector2(10, speedY);
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}

	void OnGUI() {
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x + 20, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}
	
	void Update() {
		if (barDisplay < 0)
			barDisplay = 0;
		if (!gameController.planningStage && barDisplay != 0) {
			barDisplay -= decay;
		}
		if (barDisplay == 0) {
			gameController.gameOver ();
		}
	}
}