using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpBehaviour : MonoBehaviour {

	private static float speed = 18f;
	private static float height = 6f;
	private static float timeUp = height/speed;

	private int state = 0;
	private Vector3 move;
	private float time;
	private float timeAir;

	void Update()
	{
		if ((state > 0) && (state < 3))
		{
			time += Time.deltaTime;

			if ((state == 1) && (time > timeUp))
			{
				state++;
				time = 0;
				Vector3 forward = transform.forward.normalized;
				rigidbody.velocity = new Vector3 (forward.x, 0, forward.z) * speed;
				timeAir = new Vector3(2 * Instantiation.instance.getSpaceX() * forward.x,
					                  0,
					                  2 * Instantiation.instance.getSpaceZ() * forward.z).magnitude / speed;
					
			}

			if ((state == 2) && (time > timeAir))
			{
				state++;
				time = 0;
				rigidbody.useGravity = true;
				rigidbody.velocity = new Vector3 (0, -speed, 0);
			}
		}
	}

	public void Jump()
	{
		state = 1;
		time = 0f;
		gameObject.SendMessage("setStopped", true);
		rigidbody.useGravity = false;
		rigidbody.velocity = new Vector3 (0, speed, 0);
	}
}
