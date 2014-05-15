using UnityEngine;
using System.Collections;

public class retryButton : MonoBehaviour {
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
	
	void OnMouseDown()
	{
		//GameObject.FindGameObjectWithTag ("Sound Player").GetComponent<SoundPlayerScript> ().switchToMenuMusic ();
		// Reload the level
		Application.LoadLevel(Application.loadedLevel);
	}
}
