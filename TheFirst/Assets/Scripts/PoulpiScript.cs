using UnityEngine;
using System.Collections;

public class PoulpiScript : MonoBehaviour {

	public Vector2 speed = new Vector2(5, 5);
	public Vector2 direction = new Vector2(-1, 0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moment = new Vector3 (speed.x * direction.x, speed.y * direction.y);
		moment *= Time.deltaTime;
		transform.Translate (moment);
	}
}
