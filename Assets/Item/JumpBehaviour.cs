using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpBehaviour : MonoBehaviour {

	private static float speed = 18f;
	private static float height = 6f;
	private static float timeUp = height/speed;

	private static float slideStep = 1f;
	private StoppableObject stoppableObject;

	private Vector3 newPosition = Vector3.zero;

	private int state = 0;
	private Vector3 move;
	private float time;
	private float timeAir;

	void Update()
	{
		if (state != 0)
		{
			time += Time.deltaTime;

			if ((state == 1) && (time > timeUp))
			{
				state++;
				time = 0;
				Vector3 forward = transform.forward.normalized;
				rigidbody.velocity = new Vector3 (forward.x, 0, forward.z) * speed;
				timeAir = new Vector3(2 * AssemblyCSharp.Instantiation.instance.getSpaceX() * forward.x,
					                  0,
					                  2 * AssemblyCSharp.Instantiation.instance.getSpaceZ() * forward.z).magnitude / speed;
					
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

	void OnCollisionEnter (Collision collision)
	{
		if (state != 0)
		{
			if (collision.collider.name == "Ground")
			{
				gameObject.SendMessage("setStopped", false);
				state = 0;
			}

			if (collision.collider.tag == "Wall")
			{
				float stepX = 0f;
				float stepZ = 0f;
				Vector3 center = collision.collider.gameObject.transform.position;
				bool verticalWall = collision.collider.gameObject.transform.eulerAngles.y != 0;
				if (verticalWall)
				{
					stepX = -slideStep;
					if (transform.position.x > center.x)
					{
						stepX = slideStep;
					}
				}
				else
				{
					stepZ = -slideStep;
					if (transform.position.z > center.z)
					{
						stepZ = slideStep;
					}
				}
				rigidbody.velocity = new Vector3(rigidbody.velocity.x + stepX, rigidbody.velocity.y, rigidbody.velocity.z + stepZ);
			}
			
			if (collision.collider.tag == "Pillar")
			{
				float stepX = 0f;
				float stepZ = 0f;
				Vector3 center = collision.collider.gameObject.transform.position;
				
				stepX = -slideStep;
				if (transform.position.x > center.x)
				{
					stepX = slideStep;
				}
				
				stepZ = -slideStep;
				if (transform.position.z > center.z)
				{
					stepZ = slideStep;
				}
				
				rigidbody.velocity = new Vector3(rigidbody.velocity.x + stepX, rigidbody.velocity.y, rigidbody.velocity.z + stepZ);
			}
		}

		/*if (newPosition != Vector3.zero)
		{
			if (collision.collider.tag == "Wall")
			{
				float stepX = 0f;
				float stepZ = 0f;
				Vector3 center = collision.collider.gameObject.transform.position;
				bool verticalWall = collision.collider.gameObject.transform.eulerAngles.y != 0;
				if (verticalWall)
				{
					stepX = -slideStep;
					if (transform.position.x > center.x)
					{
						stepX = slideStep;
					}
				}
				else
				{
					stepZ = -slideStep;
					if (transform.position.z > center.z)
					{
						stepZ = slideStep;
					}
				}
				newPosition = new Vector3(newPosition.x + stepX, newPosition.y, newPosition.z + stepZ);
			}

			if (collision.collider.tag == "Pillar")
			{
				float stepX = 0f;
				float stepZ = 0f;
				Vector3 center = collision.collider.gameObject.transform.position;

				stepX = -slideStep;
				if (transform.position.x > center.x)
				{
					stepX = slideStep;
				}

				stepZ = -slideStep;
				if (transform.position.z > center.z)
				{
					stepZ = slideStep;
				}

				newPosition = new Vector3(newPosition.x + stepX, newPosition.y, newPosition.z + stepZ);
			}

			if ((collision.collider.gameObject.name != "egypt_border_deco") &&
				(collision.collider.gameObject.name != "Ground") && 
			    (collision.collider.tag != "Pillar") &&
			    (collision.collider.tag != "Wall"))
			{
				// calculate forward because it is wrong
				Vector3 forward = Quaternion.Euler(0, -90, 0) * collision.collider.transform.forward;
				state++;
				newPosition = new Vector3(transform.localPosition.x + forward.x * 3, 
                                          transform.localPosition.y - 5,
				                          transform.localPosition.z + forward.z * 3);
			}
		}*/
	}

}
