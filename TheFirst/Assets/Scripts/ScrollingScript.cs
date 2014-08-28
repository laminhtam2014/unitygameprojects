using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {
	public Vector2 speed = new Vector2(2,2);
	public Vector2 direction = new Vector2(-1, 0);
	public bool isLinkedToCamera = false;
	public bool isLooping = false;
	private List<Transform> backgroundPart;
	// Use this for initialization
	void Start () {
		if (isLooping) {
			backgroundPart = new List<Transform>();
			for(int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if(child.renderer != null)
				{
					backgroundPart.Add(child);
				}
			}
			backgroundPart = backgroundPart.OrderBy(
				t => t.position.x
				).ToList();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y);
		movement *= Time.deltaTime;
		transform.Translate (movement);
		if (isLinkedToCamera) {
			Camera.main.transform.Translate(movement);
		}

		if (isLooping) {
			Transform firstChild = backgroundPart.FirstOrDefault();
			if (firstChild != null)
			{
				// Check if the child is already (partly) before the camera.
				// We test the position first because the IsVisibleFrom
				// method is a bit heavier to execute.
				if (firstChild.position.x < Camera.main.transform.position.x)
				{
					// If the child is already on the left of the camera,
					// we test if it's completely outside and needs to be
					// recycled.
					if (firstChild.renderer.IsVisibleFrom(Camera.main) == false)
					{
						// Get the last child position.
						Transform lastChild = backgroundPart.LastOrDefault();
						Vector3 lastPosition = lastChild.transform.position;
						Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);
						
						// Set the position of the recyled one to be AFTER
						// the last child.
						// Note: Only work for horizontal scrolling currently.
						firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);
						
						// Set the recycled child to the last position
						// of the backgroundPart list.
						backgroundPart.Remove(firstChild);
						backgroundPart.Add(firstChild);
					}
				}
			}
		}
	}
}
