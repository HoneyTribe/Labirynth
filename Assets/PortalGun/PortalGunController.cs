using UnityEngine;
using System.Collections;

public class PortalGunController : MonoBehaviour {

	public static PortalGunController instance;

	private static float rotationSpeed = 15f;
	private static float energySpeed = 0.5f;
	private const float power = 1000f;

	private GameObject portal;
	private Vector3 rotationPoint;

	void Start()
	{
		rotationSpeed *= LevelFinishedController.instance.gameSpeed;
		rotationPoint = new Vector3 (transform.position.x,
		           					 transform.position.y,
		                             transform.position.z - transform.localScale.z / 2f);
		Vector3 neck = new Vector3(transform.position.x - rotationPoint.x,
		                           transform.position.y - rotationPoint.y,
		                           transform.position.z - rotationPoint.z);
		Vector3 rotationAxis = Vector3.Cross(neck, Vector3.up);
		transform.RotateAround (rotationPoint, rotationAxis, 20f);

		portal = GameObject.Find ("Portal");
		instance = this;
	}

	public void Shoot()
	{
		portal.rigidbody.useGravity = true;
		portal.collider.isTrigger = false;
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("players"), LayerMask.NameToLayer("item"), true);
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("monsters"), LayerMask.NameToLayer("item"), true);
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("flyingMonsters"), LayerMask.NameToLayer("item"), true);

		portal.transform.parent = null;
		Vector3 neck = new Vector3(transform.position.x - rotationPoint.x,
		                           transform.position.y - rotationPoint.y,
		                           transform.position.z - rotationPoint.z);
		
		portal.rigidbody.AddForce (neck.normalized * power * PortalGunPowerController.instance.getEnergy());
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

		if (input.z > 0)
		{
			PortalGunPowerController.instance.changeEnergy(energySpeed * Time.deltaTime);
		}

		if (input.z < 0)
		{
			PortalGunPowerController.instance.changeEnergy(-energySpeed * Time.deltaTime);
		}
	}
}
