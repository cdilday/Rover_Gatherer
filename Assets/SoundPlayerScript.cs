using UnityEngine;
using System.Collections;

public class SoundPlayerScript : MonoBehaviour {

	public AudioClip BackgroundMusic;
	public AudioSource menuMusic;
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
		if (playMusic) {
			if(Application.loadedLevel == 0 || Application.loadedLevel == 1)
			{
				menuMusic.Play();
			}
			else
				audio.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void playMenu()
	{
		menuMusic.Play ();
	}
}
