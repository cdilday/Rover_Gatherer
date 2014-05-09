using UnityEngine;
using System.Collections;

public class arrowScript : MonoBehaviour {

	public bool dragging = false;
	private dragDrop drag;
	// Use this for initialization
	void Start () {
		drag = this.GetComponent <dragDrop> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!drag.dragging){
			this.transform.position = new Vector3(gameObject.transform.parent.transform.position.x, 
			                                      gameObject.transform.parent.transform.position.y,
			                                      -1);
			this.transform.rotation = new Quaternion(0,0,0,0);
		}
	}
}
