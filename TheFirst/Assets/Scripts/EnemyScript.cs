using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	private WeaponScript weapon;
	private bool hasSpawn;
	private PoulpiScript move;
	void Awake()
	{
		weapon = GetComponent<WeaponScript>();
		move = GetComponent<PoulpiScript>();
	}
	// Use this for initialization
	void Start () {
		hasSpawn = false;
		collider2D.enabled = false;
		move.enabled = false;
		weapon.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasSpawn == false) {
			if (renderer.IsVisibleFrom (Camera.main)) {
				Spawn ();
			}
		} else {
			if (weapon != null && weapon.fShotCoolDown <= 0) {
				weapon.Attack (true);
				SoundEffectsHelper.Instance.MakeEnemyShotSound();
			}
			if (renderer.IsVisibleFrom (Camera.main) == false) {
				Destroy (gameObject);
			}
		}
	}
	private void Spawn()
	{
		hasSpawn = true;
		move.enabled = true;
		weapon.enabled = true;
		collider2D.enabled = true;
	}
}
