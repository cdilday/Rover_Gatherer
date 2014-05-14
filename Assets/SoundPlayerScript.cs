﻿using UnityEngine;
using System.Collections;

public class SoundPlayerScript : MonoBehaviour {

	public AudioSource BackgroundMusic;
	public AudioSource menuMusic;
	public bool playMusic; //this is for just the background music. 
	public bool newLevel = false;
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
			{
				BackgroundMusic.Play();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (newLevel){
			if(Application.loadedLevelName.StartsWith ("s")) {
				menuMusic.Stop();
				BackgroundMusic.Play ();
				newLevel = false;
			}
		}
	}

	public void switchToMenuMusic()
	{
		BackgroundMusic.Stop ();
		menuMusic.Play ();
	}
}
