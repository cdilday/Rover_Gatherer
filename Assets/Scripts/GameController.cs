using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool planningStage;
	public bool canMoveArrows;
	public bool isGameOver = false;
	public int mineralsIn = 0; // number of minerals gathered
	public int mineralsTotal = 3; //number of minerals out
	// Use this for initialization
	void Start () {
		planningStage = true;
		canMoveArrows = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && planningStage) {
			planningStage = false; //temporally removed for prototype purpose
			//canMoveArrows = false;
		}
		if (mineralsIn == mineralsTotal && !isGameOver) {
			success();
		}
	}

	//this is where the gameover will happen. Anything that causes a game over should call this
	public void gameOver()
	{
		gameObject.AddComponent<gameOverScript>();
		isGameOver = true;
	}
	public void success()
	{
		gameObject.AddComponent<SuccessScript>();
		isGameOver = true;
	}
}
