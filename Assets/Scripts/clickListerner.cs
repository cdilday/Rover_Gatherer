using UnityEngine;
using System.Collections;

public class clickListerner : MonoBehaviour {
	public string levelName;
	private Color mouseOverColor = Color.cyan;
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
		Application.LoadLevel(levelName);
		GameObject.FindGameObjectWithTag ("Sound Player").GetComponent<SoundPlayerScript> ().newLevel = true;
	}

}
