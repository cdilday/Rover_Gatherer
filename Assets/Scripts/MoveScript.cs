using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	private GameController gameController; //this will allow access to the game controller
	public Vector2 speed = new Vector2(10, 10);

	//public float speedY = 0;
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(0, -1);
	
	private Vector2 movement;
	
	void Start()
	{
		//speed = new Vector2(10, speedY);
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	
	void Update()
	{
		Vector3 currentPos = transform.position;
		// 2 - Movement
		if (!gameController.planningStage && !gameController.isGameOver) {
			movement = new Vector2 (
			speed.x * direction.x,
			speed.y * direction.y);
		}
		else
			movement = new Vector2 ( 0, 0);
		if ((currentPos.y > 4.64 || currentPos.y < -5.64 || currentPos.x > 4 || currentPos.x < -8) && !gameController.isGameOver) {
			gameController.gameOver ();
		}

	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
	}
}