﻿using UnityEngine;
using System.Collections;

public class clickListerner : MonoBehaviour {
	public string levelName;
	private Color mouseOverColor = Color.blue;
	private Color originalColor ;


	void OnMouseEnter()
	{
			originalColor = gameObject.renderer.material.GetColor ("_Color");
			gameObject.renderer.material.color = mouseOverColor;

	}

	void OnMouseExit()
	{
		gameObject.renderer.material.color = originalColor;

	}

		void OnMouseDown() {
			if(levelName.StartsWith("s"))
			{
				GameObject.FindGameObjectWithTag ("Sound Player").audio.Play ();
			}
			Application.LoadLevel(levelName);
		}

}
