﻿using UnityEngine;
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
			this.transform.position = new Vector3(this.transform.position.x, 
			                                      this.transform.position.y,
			                                      0);
		}
	}
}