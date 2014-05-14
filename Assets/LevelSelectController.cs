using UnityEngine;
using System.Collections;

public class LevelSelectController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("Sound Player").GetComponent<SoundPlayerScript> ().playMusic = false;
		GameObject.FindGameObjectWithTag ("Sound Player").audio.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag ("Sound Player").GetComponent<SoundPlayerScript> ().playMusic = true;
	}
}
