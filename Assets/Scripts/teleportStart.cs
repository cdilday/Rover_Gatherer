using UnityEngine;
using System.Collections;

public class teleportStart : MonoBehaviour {


	private teleportEnd telEnd;
	public int coolDown;
	// Use this for initialization
	void Start () {
		telEnd = GameObject.Find ("Teleporter End").GetComponent<teleportEnd> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (coolDown > 0)
			coolDown--;
	}


	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a robot?
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null && coolDown == 0)
		{
			rob.transform.position = new Vector3(telEnd.transform.position.x,
			                                     telEnd.transform.position.y,
			                                     rob.transform.position.z);
			telEnd.coolDown = 120;

		}
	}

}
