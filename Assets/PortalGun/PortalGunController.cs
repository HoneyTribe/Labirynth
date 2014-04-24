using UnityEngine;
using System.Collections;

public class PortalGunController : MonoBehaviour {

	public static PortalGunController instance;

	private static float rotationSpeed = 15f;
	private const float power = 800f;

	private GameObject portal;
	private Vector3 rotationPoint;

	void Start()
	{
		rotationSpeed *= LevelFinishedController.instance.gameSpeed;
		rotationPoint = new Vector3 (transform.position.x,
		           					 transform.position.y,
		                             transform.position.z - transform.localScale.z / 2f);
		portal = GameObject.Find ("Portal");
		instance = this;
	}

	public void Shoot()
	{
		if (!PortalGunPowerController.instance.isHolding())
		{
			PortalGunPowerController.instance.holding(true);
		}
		else
		{
			portal.rigidbody.isKinematic = false;
			portal.transform.parent = null;
			Vector3 neck = new Vector3(transform.position.x - rotationPoint.x,
			                           transform.position.y - rotationPoint.y,
			                           transform.position.z - rotationPoint.z);
			
			portal.rigidbody.AddForce (neck.normalized * power * PortalGunPowerController.instance.getEnergy());
			PortalGunPowerController.instance.holding(false);
		}
	}
		
	public void Move(Vector3 input)
	{
		if ((input.x > 0) && (transform.rotation.y < 0.6))
		{
			transform.RotateAround (rotationPoint, Vector3.up, rotationSpeed * Time.deltaTime);
		}

		if ((input.x < 0) && (transform.rotation.y > -0.6))
		{
			transform.RotateAround (rotationPoint, Vector3.up, -rotationSpeed * Time.deltaTime);
		}

		if (input.z != 0)
		{
			Vector3 neck = new Vector3(transform.position.x - rotationPoint.x,
			                           transform.position.y - rotationPoint.y,
			                           transform.position.z - rotationPoint.z);
			Vector3 rotationAxis = Vector3.Cross(neck, Vector3.up);

			if ((input.z > 0) && (transform.rotation.x <= 0.0))
			{
				transform.RotateAround (rotationPoint, rotationAxis, -rotationSpeed * Time.deltaTime);
			}

			if ((input.z < 0) && (transform.rotation.x > -0.4))
			{
				transform.RotateAround (rotationPoint, rotationAxis, rotationSpeed * Time.deltaTime);
			}
		}
	}
}
