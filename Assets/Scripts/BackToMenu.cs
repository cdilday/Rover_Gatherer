using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag ("Sound Player").GetComponent<SoundPlayerScript> ().switchToMenuMusic ();
		Application.LoadLevel ("levelSelection");
	}
}
