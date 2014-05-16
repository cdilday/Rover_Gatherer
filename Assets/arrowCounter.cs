using UnityEngine;
using System.Collections;

public class arrowCounter : MonoBehaviour {

	public GUIText UpArrowText;
	public GUIText DownArrowText;
	public GUIText LeftArrowText;
	public GUIText RightArrowText;
	public GUIText UpFlipArrowText;
	public GUIText DownFlipArrowText;
	public GUIText LeftFlipArrowText;
	public GUIText RightFlipArrowText;
	public int UpCount = 0;
	public int DownCount = 0;
	public int LeftCount = 0;
	public int RightCount = 0;
	public int UpFlipCount = 0;
	public int DownFlipCount = 0;
	public int LeftFlipCount = 0;
	public int RightFlipCount = 0;
	GameObject[] arrowCountList;





	// Use this for initialization
	void Start () {
		arrowCountList = GameObject.FindGameObjectsWithTag ("arrow");
		int i;
		for (i = 0; i < arrowCountList.Length; i++) {
			switch (arrowCountList[i].name)
			{
				case "up":
					UpCount++;
					break;
				case "down":
					DownCount++;
					break;
				case "left":
					LeftCount++;
					break;
				case "right":
					RightCount++;
					break;
				case "up_Flip":
					UpFlipCount++;
					break;
				case "down_Flip":
					DownFlipCount++;
					break;
				case "left_Flip":
					LeftFlipCount++;
					break;
				case "right_Flip":
					RightFlipCount++;
					break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(UpArrowText != null){
			if (UpCount <= 0)
				UpArrowText.text = "";
			else
				UpArrowText.text = "x" + UpCount;
		}

		if(DownArrowText != null){
			if (DownCount <= 0)
				DownArrowText.text = "";
			else
				DownArrowText.text = "x" + DownCount;
		}

		if(LeftArrowText != null){
			if (LeftCount <= 0)
				LeftArrowText.text = "";
			else
				LeftArrowText.text = "x" + LeftCount;
		}
		
		if(RightArrowText != null){
			if (RightCount <= 0)
				RightArrowText.text = "";
			else
				RightArrowText.text = "x" + RightCount;
		}

		if(UpFlipArrowText != null){
			if (UpFlipCount <= 0)
				UpFlipArrowText.text = "";
			else
				UpFlipArrowText.text = "x" + UpFlipCount;
		}
		
		if(DownFlipArrowText != null){
			if (DownFlipCount <= 0)
				DownFlipArrowText.text = "";
			else
				DownFlipArrowText.text = "x" + DownFlipCount;
		}
		
		if(LeftFlipArrowText != null){
			if (LeftFlipCount <= 0)
				LeftFlipArrowText.text = "";
			else
				LeftFlipArrowText.text = "x" + LeftFlipCount;
		}
		
		if(RightFlipArrowText != null){
			if (RightFlipCount <= 0)
				RightFlipArrowText.text = "";
			else
				RightFlipArrowText.text = "x" + RightFlipCount;
		}

	}
}
