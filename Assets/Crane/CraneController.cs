using UnityEngine;
using System.Collections;

public class CraneController : MonoBehaviour {

	public static CraneController instance;

	private static float rotationSpeed = 66f;
	private static float extentionSpeed = 10f;
	private static float retractingSpeed = 30f;

	private Vector3 rotationPoint;
	private GameObject grabber;
	private CraneGrabberController grabberController;
	private GameObject craneLight;
	private float neckSize;

	private bool retracting;
	private bool entered;

	void Start()
	{
		rotationPoint = new Vector3 (transform.position.x,
		           					 transform.position.y,
		                             transform.position.z - transform.localScale.z / 2f);
		neckSize = transform.localScale.z;
		grabber = GameObject.Find ("Grabber");
		grabberController = grabber.GetComponent<CraneGrabberController> ();
		craneLight = GameObject.Find ("CraneLight");
		instance = this;
	}

	public bool isEntered()
	{
		return entered;
	}

	void Update()
	{
		if (retracting)
		{
			Move (new Vector3(0,0,-1));
		}
	}

	public void PickUp() 
	{
		grabber.SendMessage ("PickUp");
	}

	public void Move(Vector3 input)
	{
		if ((!grabberController.isPickingUp()) && (!grabberController.isSmashing()))
		{
			float newRotationSpeed = rotationSpeed * neckSize / Mathf.Sqrt(transform.localScale.z) ;

			Vector3 neckPosition = transform.localPosition;
			Quaternion neckRotation = transform.localRotation;
			Vector3 neckScale = transform.localScale;
			Vector3 grabberPos = grabber.transform.localPosition;

			if ((input.x > 0) && (transform.rotation.y < 0.6))
			{
				transform.RotateAround (rotationPoint, Vector3.up, input.x * newRotationSpeed * Time.deltaTime);
				grabber.transform.RotateAround (rotationPoint, Vector3.up, input.x * newRotationSpeed * Time.deltaTime);
			}

			if ((input.x < 0) && (transform.rotation.y > -0.6))
			{
				transform.RotateAround (rotationPoint, Vector3.up, input.x * newRotationSpeed * Time.deltaTime);
				grabber.transform.RotateAround (rotationPoint, Vector3.up, input.x * newRotationSpeed * Time.deltaTime);
			}

			RestorePosition (neckPosition, neckRotation, neckScale, grabberPos);
			neckPosition = transform.localPosition;
			neckRotation = transform.localRotation;
			neckScale = transform.localScale;
			grabberPos = grabber.transform.localPosition;

			if (input.z != 0)
			{
				Vector3 distance = transform.position - rotationPoint;
				Vector3 grabberDistance = grabber.transform.position - rotationPoint;

				float step = input.z * Time.deltaTime;
				if (retracting)
				{
					step *= retractingSpeed;
				}
				else
				{
					step *= extentionSpeed;
				}

				if (transform.localScale.z + step >= 1.52)
				{
					transform.localScale = new Vector3 (transform.localScale.x,
					                                    transform.localScale.y,
					                                    transform.localScale.z + step);
					transform.position = rotationPoint + distance + distance.normalized * step / 2;
					grabber.transform.position = rotationPoint + grabberDistance + distance.normalized * step;
				}
				else
				{
					retracting = false;
				}
			}

			RestorePosition (neckPosition, neckRotation, neckScale, grabberPos);
		}
	}

	public void TurnOn ()
	{
		entered = true;
		craneLight.SendMessage ("TurnOn");
		if(LevelFinishedController.instance.getLevel() == 5 )
		{
			FloorInstructions.instance.ChangeInstructions();
		}
		retracting = false;
	}
	
	public void TurnOff ()
	{
		entered = false;
		grabber.SendMessage("ForceDrop");
		craneLight.SendMessage ("TurnOff");
		if(LevelFinishedController.instance.getLevel() == 5 )
		{
			FloorInstructions.instance.ChangeInstructions();
		}
		retracting = true;
	}

	public void SmashWall ()
	{
		grabber.SendMessage ("Smash");
	}

//	void OnTriggerEnter (Collider currentCollider)
//	{
//		ff = true;
//		Debug.Log ("Collide1" + transform.localPosition);
//		transform.localPosition = new Vector3 (this.neckPosition.x,
//		                                       this.neckPosition.y,
//		                                       this.neckPosition.z);		                                      
//		transform.localRotation = new Quaternion (this.neckRotation.x,
//		                                          this.neckRotation.y,
//		                                          this.neckRotation.z,
//		                                          this.neckRotation.w);
//		transform.localScale = new Vector3 (this.neckScale.x,
//		                                    this.neckScale.y,
//		                                    this.neckScale.z);
//		grabber.transform.localPosition = new Vector3 (this.grabberPosition.x,
//		                                               this.grabberPosition.y,
//		                                               this.grabberPosition.z);
//		Debug.Log ("Collide2" + transform.localPosition);
//
//	}
//
//	void OnTriggerExit (Collider currentCollider)
//	{
//		ff = false;
//		Debug.Log ("Exit");
//	}

	private void RestorePosition(Vector3 neckPosition, Quaternion neckRotation, Vector3 neckScale, Vector3 grabberPos)
	{
		Vector3[] boundingBox = new Vector3[4];
		boundingBox[0] = renderer.bounds.max;
		boundingBox[1] = new Vector3(renderer.bounds.min.x, renderer.bounds.max.y, renderer.bounds.min.z);
		boundingBox[2] = new Vector3(renderer.bounds.min.x, renderer.bounds.max.y, renderer.bounds.max.z);
		boundingBox[3] = new Vector3(renderer.bounds.max.x, renderer.bounds.max.y, renderer.bounds.min.z);
		
		bool collisionDetected = false;
		foreach (Vector3 v in boundingBox)
		{
			if ((Mathf.Abs (v.x) > 19) || (Mathf.Abs (v.z) > 23))
			{
				collisionDetected = true;
				break;
			}
		}
		
		if (collisionDetected)
		{
			transform.localPosition = neckPosition;		                                      
			transform.localRotation = neckRotation;
			transform.localScale = neckScale;
			grabber.transform.localPosition = grabberPos;
		}
	}
}
