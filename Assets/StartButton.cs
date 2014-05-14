using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	public string levelName;
	private Color mouseOverColor = Color.yellow;
	private Color originalColor ;
		
	void Update()
	{
		if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) {
			Application.LoadLevel(levelName);
			GameObject.FindGameObjectWithTag ("Sound Player").GetComponent<SoundPlayerScript> ().newLevel = true;
		}
	}
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
