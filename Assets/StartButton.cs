using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	public string levelName;
	private Color mouseOverColor = Color.yellow;
	private Color originalColor ;
		
	void Awake(){
		PlayerPrefs.SetInt("Score Level" + 1, 0);
		PlayerPrefs.SetInt("Star Count Level" + 1, 0);

		PlayerPrefs.SetInt("Score Level" + 2, 0);
		PlayerPrefs.SetInt("Star Count Level" + 2, 0);

		PlayerPrefs.SetInt("Score Level" + 3, 0);
		PlayerPrefs.SetInt("Star Count Level" + 3, 0);


		PlayerPrefs.SetInt("Score Level" + 4, 0);
		PlayerPrefs.SetInt("Star Count Level" + 4, 0);


		PlayerPrefs.SetInt("Score Level" + 5, 0);
		PlayerPrefs.SetInt("Star Count Level" + 5, 0);
		}

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
