using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public Transform ShotPrefab;
	public float fShottingRate = 0.25f;
	public float fShotCoolDown;

	// Use this for initialization
	void Start () {
		fShotCoolDown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (fShotCoolDown > 0) {
			fShotCoolDown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy)
	{
		if (fShotCoolDown <= 0) {
			fShotCoolDown = fShottingRate;
			var shotTranform = Instantiate(ShotPrefab) as Transform;
			shotTranform.position = transform.position;
			ShotScript shot = shotTranform.gameObject.GetComponent<ShotScript>();
			if(shot != null)
			{
				shot.isEnemyShoot = isEnemy;
			}
			PoulpiScript move = shotTranform.gameObject.GetComponent<PoulpiScript>();
			if(move != null)
			{
				if(isEnemy)
					move.direction = -1 * transform.right; 
				else
					move.direction = transform.right;
			}

		}
	}
}
