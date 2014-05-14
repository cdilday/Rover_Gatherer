using UnityEngine;
using System.Collections;

public class arrowScript : MonoBehaviour {

	public bool dragging = false;
	private dragDrop drag;
	private Vector3 originalPos;
	// Use this for initialization
	void Start () {
		drag = this.GetComponent <dragDrop> ();
		originalPos = transform.position;
		gameObject.transform.parent.transform.position = new Vector3(gameObject.transform.parent.transform.position.x, 
		                                                             gameObject.transform.parent.transform.position.y,
		                                                             -1);
		transform.position = new Vector3(gameObject.transform.parent.transform.position.x, 
		                                 gameObject.transform.parent.transform.position.y,
		                                 -2);
	}
	
	// Update is called once per frame
	void Update () {
		if(!drag.dragging){
			gameObject.transform.parent.transform.position = new Vector3(gameObject.transform.parent.transform.position.x, 
			                                                             gameObject.transform.parent.transform.position.y,
			                                                             -1);
			transform.position = new Vector3(gameObject.transform.parent.transform.position.x, 
			                                      gameObject.transform.parent.transform.position.y,
			                                      -2);
			this.transform.rotation = new Quaternion(0,0,0,0);
			if(transform.position.y > 4.64 || transform.position.y < -5.64 || transform.position.x > 4 || transform.position.x < -8 
			   && transform.position != originalPos)
			{
				gameObject.transform.parent.transform.position = new Vector3( originalPos.x, originalPos.y, -1);
				this.transform.position = new Vector3( originalPos.x, originalPos.y, -2);
			}
		}
	}
}
