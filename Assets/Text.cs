using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.guiText.text = "Collect 3 Samples and\nreturn them to the base."
						+ "\n\nDrag and drop the Arrows\nto direct the rover."
						+ "\nand hit space or click RUN\nto begin the expedition.";
	}
}
