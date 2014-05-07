using UnityEngine;
using System.Collections;

public class clickListerner : MonoBehaviour {
	public string levelName;

		void OnMouseDown() {
			Application.LoadLevel(levelName);
		}

}
