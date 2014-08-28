using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public Vector2 speed = new Vector2(10, 10);
	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		if (enemy != null) {
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
			
			damagePlayer = true;
			if (damagePlayer)
			{
				HealthScript playerHealth = this.GetComponent<HealthScript>();
				if (playerHealth != null) playerHealth.Damage(1);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal"); 
		float inputY = Input.GetAxis("Vertical"); 
		Vector3 moment = new Vector3 (speed.x * inputX, speed.y * inputY);
		moment *= Time.deltaTime;
		transform.Translate (moment);

		bool shot = Input.GetButtonDown ("Fire1");
		shot |= Input.GetButtonDown ("Fire2"); 

		if (shot) {
			WeaponScript weapon = GetComponent<WeaponScript>();
			if(weapon != null)
			{
				SoundEffectsHelper.Instance.MakePlayerShotSound();
				weapon.Attack(false);
			}

		}
	}
}
