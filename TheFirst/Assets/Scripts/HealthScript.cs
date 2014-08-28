using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	public int hp = 1;
	public bool isEnemy = true;
	public void Damage(int Damagecount) 
	{
		hp -= Damagecount;
		if(hp <= 0)
		{
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound();
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D othercollider)
	{
		ShotScript shot = othercollider.gameObject.GetComponent<ShotScript>();
		if (shot != null) {
			if(shot.isEnemyShoot != isEnemy)
			{
				Damage(shot.damage);
				Destroy(shot.gameObject);
			}
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
