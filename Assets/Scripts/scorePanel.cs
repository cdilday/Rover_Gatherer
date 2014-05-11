using UnityEngine;
using System.Collections;

public class scorePanel : MonoBehaviour {

	private Animator animator;
	private GameController gameController;
	private int scoreCounter;
	private int star3;
	private int star2;
	private int star1;
	private int starsEarned;
	void Awake()
	{
		// ...
		animator = GetComponent<Animator>();
		//...
	}
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		scoreCounter = gameController.timeCounter;
		star3 = gameController.timeToGet3Stars;
		star2 = gameController.timeToGet2Stars;
		star1 = gameController.timeToGet1Stars;


		if (scoreCounter > star3) {
			animator.SetInteger ("starCounter", 3);
			starsEarned = 3;
		} else if (scoreCounter > star2) {
			animator.SetInteger ("starCounter", 2);
			starsEarned = 2;
		} else if (scoreCounter > star1) {
			animator.SetInteger ("starCounter", 1);
			starsEarned = 1;
		}
		int tempScore = PlayerPrefs.GetInt("Score Level" + gameController.level, 0);
		if (tempScore < scoreCounter) {
			PlayerPrefs.SetInt("Score Level" + gameController.level, scoreCounter);
			PlayerPrefs.SetInt("Star Count Level" + gameController.level, starsEarned);
		}
	}
	
	// Update is called once per frame
	void Update () {



	}
}
