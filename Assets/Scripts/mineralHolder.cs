using UnityEngine;
using System.Collections;

public class mineralHolder : MonoBehaviour {

	public int isIncrease = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isIncrease > 0) {
			Vector3 loco = this.transform.position;
			loco.x = loco.x + 1;
			this.transform.position = loco;
			isIncrease = 0;
		}
	}
}
