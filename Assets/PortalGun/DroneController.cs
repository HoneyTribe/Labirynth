using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour {

	public static DroneController instance;
	private const float stability = 0.6f;
	private const float speed = 2.0f;
	private const float speed2 = 10.0f;
	private const float velocity = 300.0f; 
	private const float rotateSpeed = 40.0f;
	private const float hoverVerticalSpeed = 0.05f;
	private const float drag = 0.005f;
	private const float deceloration = 40.0f;
	private const float retractingSpeed = 45f;
	private const float stunBombSpeed = 12.0f;
	private const float teleportSpeed = 12.0f;

	public GameObject portalPrefab;
	public GameObject stunGunPrefab;

	private GameObject droneLight;
	private Vector3 originalPosition;
	private bool retracting;

	private PortalController firstPortal;
	private PortalController secondPortal;

	private bool entered;

	void Start()
	{
		originalPosition = transform.position;
		instance = this;
		droneLight = GameObject.Find ("targetLight");
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
		                                           originalPosition.y + (Mathf.Sin(11 * Time.time) + Mathf.Cos(15 * Time.time)) * hoverVerticalSpeed,
		                                           transform.position.z);

		float s = speed;
		if ((ClampAngle(transform.eulerAngles.x, -20, 20) != transform.eulerAngles.x) ||
		    (ClampAngle(transform.eulerAngles.z, -20, 20) != transform.eulerAngles.z))
		{
			s = speed2;
			//Debug.Log (transform.eulerAngles.x);
			//Debug.Log (transform.eulerAngles.z);
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
		droneLight.SendMessage ("TurnOn");
		retracting = false;

		if( LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneBombLevel)
		{
			FloorInstructions.instance.ChangeInstructions();
		}
	}

	public void TurnOff()
	{
		entered = false;
		droneLight.SendMessage ("TurnOff");
		rigidbody.drag = 0;
		retracting = true;

		if( LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneBombLevel)
		{
			FloorInstructions.instance.ChangeInstructions();
		}
	}

	public void Move (Vector3 move)
	{
		if (move == Vector3.zero)
		{
			rigidbody.drag = deceloration;
		}
		else
		{
			rigidbody.drag = drag;
			rigidbody.AddForce (move * Time.deltaTime * velocity);
			if (move.x != 0)
			{
				transform.Rotate(0,0,-move.x * Time.deltaTime * rotateSpeed);
			}

			if (move.z != 0)
			{
				transform.Rotate(move.z * Time.deltaTime * rotateSpeed,0,0);
			}
		}
	}

	public void Shoot ()
	{
		if (LevelFinishedController.instance.isTeleportEnabled())
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
						portal.rigidbody.velocity = -transform.up * teleportSpeed;
						AudioController.instance.Play("029_DroneTele");

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
							AudioController.instance.Play("029_DroneTele");
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
				AudioController.instance.Play("034_CancelTele");
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
		if (LevelFinishedController.instance.isStunGunEnabled())
		{
			if (DronePowerController.instance.canUseStunGun() && !isDroneTooClose())
			{
				Vector3 pos = new Vector3 (transform.position.x, 
				                           transform.position.y - 1,
				                           transform.position.z);
				GameObject stunGun = (GameObject) Instantiate (stunGunPrefab, pos, Quaternion.Euler(0, 0, 0));
				stunGun.rigidbody.velocity = -transform.up * stunBombSpeed; 

				DronePowerController.instance.usingStunGun();
				AudioController.instance.Play("019_DroneBomb");
			}
		}
	}

	private bool isDroneTooClose()
	{
		return Vector3.Distance(transform.position, originalPosition) < 2;
	}
}
