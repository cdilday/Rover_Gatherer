using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool planningStage;
	public bool canMoveArrows;
	// Use this for initialization
	void Start () {
		planningStage = true;
		canMoveArrows = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && planningStage) {
			planningStage = false; //temporally removed for prototype purpose
			//canMoveArrows = false;
		}
	}
}
