using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public AudioSource BackgroundMusic;
	//These bools will ideally be used as part of an options menu
	public bool playSound; //this is for sound in general and will override play music
	public bool playMusic; //this is for just the background music. 
	public bool planningStage;
	public bool canMoveArrows;
	public bool isGameOver = false;
	public int arrowCount = 4;
	public int arrowsOut = 4;
	GameObject[] arrowCounter;
	public int mineralsIn = 0; // number of minerals gathered
	public int mineralsTotal = 3; //number of minerals out
	GameObject[] mineralCounter;

	//timeCounter: use for score calculation. Need to find better solution
	public int timeCounter = 5000;
	public int timeToGet3Stars = 2000;
	public int timeToGet2Stars = 1000;
	public int timeToGet1Stars = 0;
	public bool startCount = false;
	public Transform scorePanelPrefab;
	public buildingScript building;

	// Use this for initialization
	void Start () {
		planningStage = true;
		canMoveArrows = true;
		if (playSound && playMusic)
			BackgroundMusic.Play ();
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

		if (startCount == true && timeCounter > 0 && !isGameOver)
			timeCounter--;
	}

	//this is where the gameover will happen. Anything that causes a game over should call this
	public void gameOver()
	{
		gameObject.AddComponent<gameOverScript>();
		isGameOver = true;
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
