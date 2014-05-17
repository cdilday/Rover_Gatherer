using UnityEngine;
using System.Collections;

public class SuccessButton : MonoBehaviour {
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
		GameObject.FindGameObjectWithTag ("Sound Player").GetComponent<SoundPlayerScript> ().switchToMenuMusic ();
		Application.LoadLevel ("levelSelection");
	}
	
}
