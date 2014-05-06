using UnityEngine;
using System.Collections;

public class teleportStart : MonoBehaviour {


	private teleportEnd telEnd;
	// Use this for initialization
	void Start () {
		telEnd = GameObject.Find ("teleportEnd").GetComponent<teleportEnd> ();
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
			rob.transform.position = telEnd.transform.position;
			
			
		}
	}

}
