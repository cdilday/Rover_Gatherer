using UnityEngine;
using System.Collections;

public class stoneScript : MonoBehaviour {

	private GameController gameController;
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider){ 
		RobotScript rob = otherCollider.gameObject.GetComponent<RobotScript>();
		if (rob != null) {
						SpecialEffectsHelper.Instance.Explosion (transform.position);
						Destroy (rob.gameObject);
						gameController.gameOver ();
						//rob.transform.position = new Vector3 (0, 0, 0);
				}


		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null) {
			SpecialEffectsHelper.Instance.Explosion (transform.position);
			Destroy (shot.gameObject);
				}

		}




}
/*

using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
	
	//private ScoreController score;
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int hp = 5;
	
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;
	
	
	public Transform powerPrefab;
	
	void Start () { 
		//score = GameObject.Find("Score").GetComponent<ScoreController>();
	}
	
	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound();
			//score.score += 100;
			// Dead!
			Destroy(gameObject);
			
			
			// Create a new powerUp
			var powerTransform = Instantiate(powerPrefab) as Transform;
			
			// Assign position
			powerTransform.position = transform.position;
			
			
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				
				
				Damage(shot.damage);
				
				
				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}
}
*/
