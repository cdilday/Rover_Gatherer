using UnityEngine;
using System.Collections;

public class buildingScript : MonoBehaviour {

	private RobotScript rob;
	private StartPosition startpos;
	public bool hasReturned = false;
	// Use this for initialization
	void Start () {
		 rob = GameObject.Find ("robot").GetComponent<RobotScript> ();
		startpos =  GameObject.Find ("Start Position").GetComponent<StartPosition> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a robot?
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null)
		{
			hasReturned = true;
		}
	}
}
