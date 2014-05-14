using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public AudioClip roverExplosion;
	public bool roverExploded = false;
	//These bools will ideally be used as part of an options menu
	public bool playSound; //this is for sound in general and will override play music
	public bool planningStage;
	public bool canMoveArrows;
	public bool isGameOver = false;
	public int arrowCount = 4;
	public int arrowsOut = 4;
	GameObject[] arrowCounter;
	public int mineralsIn = 0; // number of minerals gathered
	public int mineralsTotal = 3; //number of minerals out
	GameObject[] mineralCounter;
	//make this match the level it currently is in the inspector.
	public int level = 1;

	//timeCounter: use for score calculation. Need to find better solution
	public int timeCounter = 5000;
	public int timeToGet3Stars = 2000;
	public int timeToGet2Stars = 1000;
	public int timeToGet1Stars = 0;
	public bool startCount = false;
	public Transform scorePanelPrefab;
	public buildingScript building;


	//fast forward
	public bool fastMode = false;

	// Use this for initialization
	void Start () {
		planningStage = true;
		canMoveArrows = true;
		arrowCounter = GameObject.FindGameObjectsWithTag ("arrow");
		arrowCount = arrowCounter.Length;
		GameObject buildingObject = GameObject.Find ("Building");
		if (buildingObject != null) {
			building = buildingObject.GetComponent <buildingScript>();
		}
		mineralCounter = GameObject.FindGameObjectsWithTag ("Pick-up");
		mineralsTotal = mineralCounter.Length;
	}
	
	// Update is called once per frame
	void Update () {
		arrowCounter = GameObject.FindGameObjectsWithTag ("arrow");
		arrowsOut = arrowCounter.Length;
		if (Input.GetKey (KeyCode.Space) && planningStage) {
			planningStage = false; //temporally removed for prototype purpose
			canMoveArrows = false;
			startCount = true;
		}
		if (mineralsIn == mineralsTotal && !isGameOver && building.hasReturned) {
			success();
		}
		else if (building.hasReturned && mineralsIn != mineralsTotal && !isGameOver) {
			gameOver();
		}

		if (startCount == true && timeCounter > 0 && !isGameOver) {
			if (fastMode)
				timeCounter -= 4;
			else
				timeCounter--;
		}
	}

	//this is where the gameover will happen. Anything that causes a game over should call this
	public void gameOver()
	{
		gameObject.AddComponent<gameOverScript>();
		isGameOver = true;
		if (roverExploded && playSound)
			audio.PlayOneShot (roverExplosion);
	}
	public void success()
	{
		timeCounter += arrowsOut * 300;
		// Create a new panel
		var scorePanelTransform = Instantiate(scorePanelPrefab) as Transform;
		
		// Assign position
		scorePanelTransform.position = transform.position;
		isGameOver = true;
	}
}
