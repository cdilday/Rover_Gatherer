using UnityEngine;
using System.Collections;

public class mineralScript : MonoBehaviour {
	public AudioSource pickupSound;
	public int isPickUp = 0;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isPickUp == 1) {
						RobotScript rob = GameObject.Find ("robot").GetComponent<RobotScript> ();
						this.transform.position = rob.transform.position;
						this.transform.position = rob.transform.position;
				}
		else if (isPickUp == 2) {
			mineralHolder mine = GameObject.Find ("mineralHolder").GetComponent<mineralHolder> ();

			this.transform.position = mine.transform.position;
			mine.isIncrease = 1;
			isPickUp = 0;
			gameController.mineralsIn += 1;
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a robot?
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null)
		{
			isPickUp = 1;
			if(gameController.playSound)
				pickupSound.Play ();
			
		}
	}

}

/*
using UnityEngine;
using System.Collections;

public class healthBar : MonoBehaviour {
	
	
	private Animator animator;
	
	void Awake()
	{
		// ...
		animator = GetComponent<Animator>();
		//...
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		WizAnimation wiz = GameObject.Find("wiz").GetComponent<WizAnimation>();
		HealthScript playerHealth = wiz.GetComponent<HealthScript>();
		
		int hp = playerHealth.hp;
		animator.SetInteger ("healthCount", hp);
		
		
		
	}
}
*/
