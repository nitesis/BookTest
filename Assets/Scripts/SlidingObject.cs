using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingObject : MonoBehaviour {

	private float speed;

	// Use this for initialization
	void Start () {
		speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		// Only if there are touches
		if (Input.touches.Length > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Moved)
			{
				var x = Input.touches[0].deltaPosition.x * speed * Time.deltaTime;
				var y = Input.touches[0].deltaPosition.y * speed * Time.deltaTime;

				transform.Translate(new Vector3(x, y, 0));
			}
		}
	}

}
