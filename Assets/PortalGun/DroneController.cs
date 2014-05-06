using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour {

	public static DroneController instance;
	private const float stability = 0.5f;
	private const float speed = 2.0f;
	private const float retractingSpeed = 20f;

	public GameObject portalPrefab;
	public GameObject stunGunPrefab;

	private Vector3 originalPosition;
	private bool retracting;

	private PortalController firstPortal;
	private PortalController secondPortal;

	private bool entered;

	void Start()
	{
		originalPosition = transform.position;
		instance = this;
	}

	void Update()
	{
		if (retracting)
		{
			float distance = Vector3.Distance(transform.position, originalPosition);

			if (distance != 0)
			{
				transform.position = Vector3.Lerp (
					transform.position, originalPosition, Time.deltaTime * retractingSpeed / distance);
			}
			else
			{
				rigidbody.velocity = Vector3.zero;
				retracting = false;
			}
		}
	}

	void FixedUpdate()
	{
		rigidbody.transform.eulerAngles = new Vector3 (rigidbody.transform.eulerAngles.x,
		                                               0,
		                                               rigidbody.transform.eulerAngles.z);
		rigidbody.transform.position = new Vector3(transform.position.x,
		                                           originalPosition.y + (Mathf.Sin(11 * Time.time) + Mathf.Cos(15 * Time.time)) * 0.07f,
		                                           transform.position.z);

		float s = speed;
		if ((ClampAngle(transform.eulerAngles.x, -20, 20) != transform.eulerAngles.x) ||
		    (ClampAngle(transform.eulerAngles.z, -20, 20) != transform.eulerAngles.z))
		{
			s = 10;
			Debug.Log (transform.eulerAngles.x);
			Debug.Log (transform.eulerAngles.z);
		}
		Vector3 predictedUp = Quaternion.AngleAxis(
								rigidbody.angularVelocity.magnitude * Mathf.Rad2Deg * stability / s,
								rigidbody.angularVelocity
								) * transform.up;
		
		Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
		rigidbody.AddTorque(torqueVector * s * s);
	}

	public bool isEntered()
	{
		return entered;
	}

	public void TurnOn ()
	{
		entered = true;
		retracting = false;
	}

	public void TurnOff()
	{
		entered = false;
		rigidbody.drag = 0;
		retracting = true;
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
			rigidbody.AddForce (move * 500);
			if (move.x != 0)
			{
				transform.Rotate(0,0,-move.x * Time.deltaTime * 1000);
			}

			if (move.z != 0)
			{
				transform.Rotate(move.z * Time.deltaTime * 1000,0,0);
			}
		}
	}

	public void Shoot ()
	{
		if (LevelFinishedController.instance.getLevel() >= LevelFinishedController.instance.getFirstLevelWithDrone())
	    {
			if ((firstPortal == null) ||  (secondPortal == null))
			{
				if (DronePowerController.instance.canSetUp() && !isDroneTooClose())
				{
					if ((firstPortal == null) ||
						((firstPortal != null) && (firstPortal.isSettled())))
					{
						Vector3 pos = new Vector3 (transform.position.x, 
						                           transform.position.y - 1,
						                           transform.position.z);
						GameObject portal = (GameObject) Instantiate (portalPrefab, pos, Quaternion.Euler(0, 0, 0));
						PortalController portalController = portal.GetComponent<PortalController>();
						portal.rigidbody.velocity = -transform.up * 10; 

						// check groundController
						Physics.IgnoreLayerCollision(LayerMask.NameToLayer("players"), LayerMask.NameToLayer("item"), true);
						Physics.IgnoreLayerCollision(LayerMask.NameToLayer("monsters"), LayerMask.NameToLayer("item"), true);
						Physics.IgnoreLayerCollision(LayerMask.NameToLayer("flyingMonsters"), LayerMask.NameToLayer("item"), true);

						if (firstPortal == null)
						{
							firstPortal = portalController;
						}
						else
						{
							secondPortal = portalController;
							firstPortal.setTheOtherPortal(secondPortal);
							secondPortal.setTheOtherPortal(firstPortal);
						}
						DronePowerController.instance.settingUp();
					}
				}
			}
			else
			{
				Destroy(firstPortal.gameObject);
				Destroy (secondPortal.gameObject);
				firstPortal = null;
				secondPortal = null;
			}
		}
	}

	private float ClampAngle(float angle, float from, float to)
	{
		bool changed = false;
		if (angle > 180)
		{
			angle = 360 - angle;
			changed = true;
		}
		angle = Mathf.Clamp(angle, from, to);

		if (changed)
		{
			angle = 360 - angle;
		}
		return angle;
	}

	public void UseStunGun ()
	{
		if (LevelFinishedController.instance.getLevel() >= LevelFinishedController.instance.getFirstLevelWithStunGun())
		{
			if (DronePowerController.instance.canUseStunGun() && !isDroneTooClose())
			{
				Vector3 pos = new Vector3 (transform.position.x, 
				                           transform.position.y - 1,
				                           transform.position.z);
				GameObject stunGun = (GameObject) Instantiate (stunGunPrefab, pos, Quaternion.Euler(0, 0, 0));
				stunGun.rigidbody.velocity = -transform.up * 10; 

				DronePowerController.instance.usingStunGun();
			}
		}
	}

	private bool isDroneTooClose()
	{
		return Vector3.Distance(transform.position, originalPosition) < 2;
	}
}
