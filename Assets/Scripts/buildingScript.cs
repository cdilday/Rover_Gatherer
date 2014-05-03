using UnityEngine;
using System.Collections;

public class buildingScript : MonoBehaviour {

	private RobotScript rob;
	private StartPosition startpos;
	// Use this for initialization
	void Start () {
		 rob = GameObject.Find ("robot").GetComponent<RobotScript> ();
		startpos =  GameObject.Find ("startPosition").GetComponent<StartPosition> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a robot?
		mineralScript mineral = otherCollider.gameObject.GetComponent<mineralScript>();
		if (mineral != null)
		{
			mineral.isPickUp = 2;
			rob.transform.position = startpos.transform.position;
			rob.directionType = 2;
			
			
		}
	}
}
