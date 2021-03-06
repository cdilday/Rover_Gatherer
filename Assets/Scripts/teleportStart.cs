﻿using UnityEngine;
using System.Collections;

public class teleportStart : MonoBehaviour {


	private teleportEnd telEnd;
	public bool isTransporting = false;
	public Sprite[] transportAnimation;

	private GameController gameController;
	private bool isFast = false;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}

		telEnd = GameObject.Find ("Teleporter End").GetComponent<teleportEnd> ();
	}
	
	// Update is called once per frame
	void Update () {
		isFast = gameController.fastMode;
	}


	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a robot?
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null && !isTransporting && !isFast)
		{
			isTransporting = true;
			telEnd.isTransporting = true;
			StartCoroutine(transportation(rob));
		}
		else if (rob != null && !isTransporting && isFast)
		{
			isTransporting = true;
			telEnd.isTransporting = true;
			//StartCoroutine(transportation(rob));
			rob.transform.position = new Vector3(telEnd.transform.position.x,
			                                    telEnd.transform.position.y,
			                                    rob.transform.position.z);
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
			rob.transform.renderer.material.color = new Color ( 1, 1, 1, 1 - (0.25f * i));

		}
		rob.transform.position = new Vector3(telEnd.transform.position.x,
		                                     telEnd.transform.position.y,
		                                     rob.transform.position.z);
		for ( i = 5 ; i <= 9; i++)
		{
			yield return new WaitForSeconds(0.25f);
			gameObject.GetComponent<SpriteRenderer>().sprite = transportAnimation [i];
			telEnd.gameObject.GetComponent<SpriteRenderer>().sprite = transportAnimation [i];
			rob.transform.renderer.material.color = new Color ( 1, 1, 1,(0.25f * (i-5f)));
		}
		rob.transform.renderer.material.color = new Color ( 1,1,1);

		move.speed = new Vector2 (1, 1);
		yield return new WaitForSeconds (1);
		isTransporting = false;
		telEnd.isTransporting = false;
	}
}
