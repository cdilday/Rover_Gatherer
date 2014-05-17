using UnityEngine;
using System.Collections;

public class congratulationsText : MonoBehaviour {


	// Use this for initialization
	void Start () {
		if (this.transform.parent.GetComponent<scorePanel> ().starsEarned != 3) {
			this.transform.position = new Vector2 (50, 50);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
