using UnityEngine;
using System.Collections;

public class starScript : MonoBehaviour {
	
	public int starType;
	// Use this for initialization
	void Start () {
		if (this.transform.parent.GetComponent<scorePanel> ().starsEarned < starType) {
			this.transform.position = new Vector2 (50, 50);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
