using UnityEngine;
using System.Collections;

public class teleportStart : MonoBehaviour {


	private teleportEnd telEnd;
	public bool isTransporting = false;
	public Sprite[] transportAnimation;
	// Use this for initialization
	void Start () {
		telEnd = GameObject.Find ("Teleporter End").GetComponent<teleportEnd> ();
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a robot?
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null && !isTransporting)
		{
			isTransporting = true;
			telEnd.isTransporting = true;
			StartCoroutine(transportation(rob));
		}
	}

	IEnumerator transportation(RobotScript rob)
	{
		MoveScript move = rob.GetComponent<MoveScript> ();
		rob.transform.position = new Vector3(transform.position.x,
		                                     transform.position.y,
		                                     rob.transform.position.z);
		move.speed = new Vector2 (0, 0);
		int i = 1;
		for ( i = 1 ; i < 5; i++)
		{
			yield return new WaitForSeconds(0.25f);
			gameObject.GetComponent<SpriteRenderer>().sprite = transportAnimation [i];
			telEnd.gameObject.GetComponent<SpriteRenderer>().sprite = transportAnimation [i];
			rob.transform.renderer.material.color = new Color ( 1,1,1, 1 - (0.25f * i));

		}
		rob.transform.position = new Vector3(telEnd.transform.position.x,
		                                     telEnd.transform.position.y,
		                                     rob.transform.position.z);
		for ( i = 5 ; i <= 9; i++)
		{
			yield return new WaitForSeconds(0.25f);
			gameObject.GetComponent<SpriteRenderer>().sprite = transportAnimation [i];
			telEnd.gameObject.GetComponent<SpriteRenderer>().sprite = transportAnimation [i];
			rob.transform.renderer.material.color = new Color ( 1,1,1,(0.25f * i));
		}
		rob.transform.renderer.material.color = new Color ( 1,1,1);

		move.speed = new Vector2 (0.9f, 0.9f);
		yield return new WaitForSeconds (1);
		isTransporting = false;
		telEnd.isTransporting = false;
	}
}
