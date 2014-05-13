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



	void OnTriggerEnter2D(Collider2D otherCollider){ 

		
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null) {
			SpecialEffectsHelper.Instance.Explosion (transform.position);
			Destroy (shot.gameObject);
		}
		
	}
}