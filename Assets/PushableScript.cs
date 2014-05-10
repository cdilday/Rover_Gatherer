using UnityEngine;
using System.Collections;

public class PushableScript : MonoBehaviour {
	
	public Transform arrowUpPrefab;
	public Transform arrowDownPrefab;
	public Transform arrowLeftPrefab;
	public Transform arrowRightPrefab;
	void Start() {
		//Physics2D.IgnoreLayerCollision(up.collider2D, collider2D);
	}
}