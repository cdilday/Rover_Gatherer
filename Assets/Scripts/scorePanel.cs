using UnityEngine;
using System.Collections;

public class scorePanel : MonoBehaviour {

	private Animator animator;
	private GameController gameController;
	private int scoreCounter;
	private int star3;
	private int star2;
	private int star1;
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


		if(scoreCounter > star3)
			animator.SetInteger ("starCounter", 3);
		else if(scoreCounter > star2)
			animator.SetInteger ("starCounter", 2);
		else
			animator.SetInteger ("starCounter", 1);
	}
	
	// Update is called once per frame
	void Update () {



	}
}
