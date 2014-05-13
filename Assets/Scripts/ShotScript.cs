using UnityEngine;

/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Damage inflicted
	/// </summary>
	//public int damage = 1;
	
	/// <summary>
	/// Projectile damage player or enemies?
	/// </summary>
	//public bool isEnemyShot = false;
	
	private GameController gameController;
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider){ 
				RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript> ();
				if (rob != null) {
						SpecialEffectsHelper.Instance.Explosion (transform.position);
						Destroy (rob.gameObject);
						gameController.gameOver ();
						//rob.transform.position = new Vector3 (0, 0, 0);
				}
		}





}