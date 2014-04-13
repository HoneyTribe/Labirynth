using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpBehaviour : MonoBehaviour {

	private static float speed = 8f;
	private static float slideStep = 1f;
	private PlayerController playerController;

	private Vector3 newPosition = Vector3.zero;

	private int state = 0;
	private Vector3 move;

	void Start()
	{
		playerController = gameObject.GetComponent<PlayerController> ();
	}

	void Update()
	{
		/*if (newPosition != Vector3.zero)
		{
			float distance = Vector3.Distance(transform.localPosition, newPosition);
			if (distance == 0)
			{
				state++;
				if (state == 1)
				{				
					Vector3 move = new Vector3(2 * AssemblyCSharp.Instantiation.instance.getSpaceX() * transform.forward.x,
					                           0,
					                           2 * AssemblyCSharp.Instantiation.instance.getSpaceZ() * transform.forward.z);
					newPosition = new Vector3(transform.localPosition.x, 
					                          transform.localPosition.y,
					                          transform.localPosition.z) + move;
				}
				else if (state == 2)
				{

					newPosition = new Vector3(transform.localPosition.x, 
					                          transform.localPosition.y - 5,
					                          transform.localPosition.z);
				}
				else
				{
					state = 0;
					newPosition = Vector3.zero;
					playerController.setInputBlocked(false);
				}
			}
			else
			{
				transform.position = Vector3.Lerp (
					transform.localPosition, newPosition, Time.deltaTime * speed / distance);
			}
		}*/
	}

	public void Jump()
	{
		state = 1;
		playerController.setInputBlocked(true);
		rigidbody.velocity = Vector3.zero;
		Vector3 move = new Vector3(AssemblyCSharp.Instantiation.instance.getSpaceX() * Vector3.forward.x,
		                           0,
		                           AssemblyCSharp.Instantiation.instance.getSpaceZ() * Vector3.forward.z);
		rigidbody.AddRelativeForce(Vector3.up * 500 + move * 60);
//		newPosition = new Vector3(transform.localPosition.x, 
//		                          transform.localPosition.y + 5,
//		                          transform.localPosition.z);
	}

	void OnCollisionEnter (Collision collision)
	{
		if (state == 1)
		{
			if (collision.collider.name == "Ground")
			{
				playerController.setInputBlocked(false);
				rigidbody.velocity = Vector3.zero;
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
