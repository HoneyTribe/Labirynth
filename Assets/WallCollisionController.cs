using UnityEngine;
using System.Collections;

public class WallCollisionController : MonoBehaviour {

	private static float slideStep = 1f;

	public void OnCollisionEnter(Collision collision)
	{
		OnTriggerEnter (collision.collider);
	}

	public void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.rigidbody == null)
		{
			return;
		}
		// let him slide with current velocity
		if (collider.rigidbody.velocity.magnitude > 0.001f)
		{
			return;
		}


		if (collider.rigidbody.useGravity == true)
		{
			if (gameObject.tag == "Wall")
			{
				float stepX = 0f;
				float stepZ = 0f;
				Vector3 center = transform.position;
				bool verticalWall = transform.eulerAngles.y != 0;
				if (verticalWall)
				{
					stepX = -slideStep;
					if (collider.transform.position.x > center.x)
					{
						stepX = slideStep;
					}
				}
				else
				{
					stepZ = -slideStep;
					if (collider.transform.position.z > center.z)
					{
						stepZ = slideStep;
					}
				}
				collider.rigidbody.velocity = new Vector3(collider.rigidbody.velocity.x + stepX,
				                                          collider.rigidbody.velocity.y, 
				                                          collider.rigidbody.velocity.z + stepZ);
			}

			if (gameObject.tag == "Pillar")
			{
				float stepX = 0f;
				float stepZ = 0f;
				Vector3 center = transform.position;
				
				stepX = -slideStep;
				if (collider.transform.position.x > center.x)
				{
					stepX = slideStep;
				}
				
				stepZ = -slideStep;
				if (collider.transform.position.z > center.z)
				{
					stepZ = slideStep;
				}
				
				collider.rigidbody.velocity = new Vector3(collider.rigidbody.velocity.x + stepX,
				                                          collider.rigidbody.velocity.y,
				                                          collider.rigidbody.velocity.z + stepZ);
			}
		}
	}
}
