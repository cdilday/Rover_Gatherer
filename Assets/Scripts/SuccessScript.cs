using UnityEngine;

/// <summary>
/// Start or quit the game
/// </summary>
public class SuccessScript : MonoBehaviour
{
	private GameController gameController;
	public Transform scorePanelPrefab;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}

		// Create a new shot
		var scorePanelTransform = Instantiate(scorePanelPrefab) as Transform;
		
		// Assign position
		scorePanelTransform.position = transform.position;
	}
	/*void OnGUI()
	{
		
		const int buttonWidth = 120;
		const int buttonHeight = 60;
		
		if (
			GUI.Button(
			// Center in X, 1/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Retry!"
			)
			)
		{
			// Reload the level
			//if(ScoreController.score > ScoreController.highScore) ScoreController.highScore = ScoreController.score;
			//ScoreController.score = 0;
			//	PlayerPrefs.SetInt("level", 1);
			Application.LoadLevel("s1");
		}
		
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Back to menu"
			)
			)
		{
			// Reload the level
			////if(ScoreController.score > ScoreController.highScore) ScoreController.highScore = ScoreController.score;
			//ScoreController.score = 0;
			//	PlayerPrefs.SetInt("level", 1);
			Application.LoadLevel("levelSelection");
		}
	}*/
}