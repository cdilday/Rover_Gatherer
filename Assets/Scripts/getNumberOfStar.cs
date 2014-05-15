using UnityEngine;
using System.Collections;

public class getNumberOfStar : MonoBehaviour {


	public Transform star3;
	public Transform star2;
	public Transform star1;
	public string levelCounter;
	private int numberOfStar;
	private bool isInit = false;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
		numberOfStar = PlayerPrefs.GetInt("Star Count Level" + levelCounter);




		if (isInit == false)
		{
			if (numberOfStar == 3) {
				// Create a new panel
				var star = Instantiate (star3) as Transform;
				// Assign position
				star.position = transform.position;
			}
			else if (numberOfStar == 2) {
				// Create a new panel
				var star = Instantiate (star2) as Transform;
				// Assign position
				star.position = transform.position;
			}
			else if (numberOfStar == 1) {
				// Create a new panel
				var star = Instantiate (star1) as Transform;
				// Assign position
				star.position = transform.position;
			}

			isInit = true; // prevent instantiate the same obj many times
				
		}

	}
}
