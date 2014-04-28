using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour {

	public static DroneController instance;

	public GameObject portalPrefab;

	private float yPos;

	private float stability = 0.5f;
	private float speed = 2.0f;

	void Start()
	{
		yPos = transform.position.y;
		instance = this;
	}

	void FixedUpdate()
	{
		rigidbody.transform.position = new Vector3(transform.position.x,
		                                           yPos + (Mathf.Sin(11 * Time.time) + Mathf.Cos(15 * Time.time)) * 0.07f,
		                                           transform.position.z);
		Vector3 predictedUp = Quaternion.AngleAxis(
			rigidbody.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed,
			rigidbody.angularVelocity
			) * transform.up;
		
		Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
		rigidbody.AddTorque(torqueVector * speed * speed);
	}

	public void Move (Vector3 move)
	{
		if (move == Vector3.zero)
		{
			rigidbody.drag = 2;
		}
		else
		{
			rigidbody.drag = 0;
			rigidbody.angularDrag = 0;
			rigidbody.AddForce (move * 500);
			if (move.x != 0)
			{
				if ((transform.localScale.z < 30) && (transform.localScale.z > -30))
				{
					transform.Rotate(0,0,-move.x * 30);
				}
			}

			if (move.z != 0)
			{
				if ((transform.localScale.x < 30) && (transform.localScale.x > -30))
				{
					transform.Rotate(move.z * 30,0,0);
				}
			}
		}
	}

	public void Shoot ()
	{
		Vector3 pos = new Vector3 (transform.position.x, 
		                           transform.position.y - 1,
		                           transform.position.z);
		GameObject portal = (GameObject) Instantiate (portalPrefab, pos, Quaternion.Euler(0, 0, 0)); 
		portal.rigidbody.velocity = Vector3.down * 10;
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("players"), LayerMask.NameToLayer("item"), false);
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("monsters"), LayerMask.NameToLayer("item"), false);
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("flyingMonsters"), LayerMask.NameToLayer("item"), false);

	}

}
