using UnityEngine;
using System.Collections;

public class SoundPlayerScript : MonoBehaviour {

	public AudioClip BackgroundMusic;
	public bool playMusic; //this is for just the background music. 
	bool newLevel = false;
	// Use this for initialization

	void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}
	void Start () {
		if (GameObject.FindGameObjectsWithTag ("Sound Player").Length >= 2) {
			Destroy (this.gameObject);
		}
		if(playMusic)
			audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
