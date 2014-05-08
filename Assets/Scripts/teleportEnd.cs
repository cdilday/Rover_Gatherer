using UnityEngine;
using System.Collections;

public class teleportEnd : MonoBehaviour {

	private teleportStart telStart;
	public int coolDown;
	// Use this for initialization
	void Start () {
		telStart = GameObject.Find ("Teleporter Start").GetComponent<teleportStart> ();
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
			rob.transform.position = telStart.transform.position;
			telStart.coolDown = 120;
			
		}
	}
}
