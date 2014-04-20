using UnityEngine;
using System.Collections;

public class CraneController : MonoBehaviour {

	public static CraneController instance;

	private float rotationSpeed = 25f;
	private float extentionSpeed = 10f;

	private Vector3 rotationPoint;
	private GameObject grabber;
	private GameObject craneLight;

	private Vector3 neckPosition;
	private Quaternion neckRotation;
	private Vector3 neckScale;
	private Vector3 grabberPosition;

	void Start()
	{
		rotationSpeed *= LevelFinishedController.instance.gameSpeed;
		rotationPoint = new Vector3 (transform.position.x,
		           					 transform.position.y,
		                             transform.position.z - transform.localScale.z / 2f);
		grabber = GameObject.Find ("Grabber");
		craneLight = grabber.transform.Find ("CraneLight").gameObject;
		instance = this;
	}

	void Move(Vector3 input) // x,z,action
	{
		this.neckPosition = transform.localPosition;
		this.neckRotation = transform.localRotation;
		this.neckScale = transform.localScale;
		this.grabberPosition = grabber.transform.localPosition;

		if ((input.x > 0) && (transform.rotation.y < 0.6))
		{
			transform.RotateAround (rotationPoint, Vector3.up, rotationSpeed * Time.deltaTime);
			grabber.transform.RotateAround (rotationPoint, Vector3.up, rotationSpeed * Time.deltaTime);
		}

		if ((input.x < 0) && (transform.rotation.y > -0.6))
		{
			transform.RotateAround (rotationPoint, Vector3.up, -rotationSpeed * Time.deltaTime);
			grabber.transform.RotateAround (rotationPoint, Vector3.up, -rotationSpeed * Time.deltaTime);
		}

		RestorePosition ();
		this.neckPosition = transform.localPosition;
		this.neckRotation = transform.localRotation;
		this.neckScale = transform.localScale;
		this.grabberPosition = grabber.transform.localPosition;

		if (input.z != 0)
		{
			Vector3 distance = transform.position - rotationPoint;
			Vector3 grabberDistance = grabber.transform.position - rotationPoint;

			float step = Mathf.Sign(input.z) * extentionSpeed * Time.deltaTime;
			if (transform.localScale.z + step >= 2)
			{
				transform.localScale = new Vector3 (transform.localScale.x,
				                                    transform.localScale.y,
				                                    transform.localScale.z + step);
				transform.position = rotationPoint + distance + distance.normalized * step / 2;
				grabber.transform.position = rotationPoint + grabberDistance + distance.normalized * step;
			}
		}

		RestorePosition ();
	}

	public void TurnOn ()
	{
		craneLight.SendMessage ("TurnOn");
	}
	
	public void TurnOff ()
	{
		craneLight.SendMessage ("TurnOff");
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

	private void RestorePosition()
	{
		Vector3[] boundingBox = new Vector3[4];
		boundingBox[0] = renderer.bounds.max;
		boundingBox[1] = new Vector3(renderer.bounds.min.x, renderer.bounds.max.y, renderer.bounds.min.z);
		boundingBox[2] = new Vector3(renderer.bounds.min.x, renderer.bounds.max.y, renderer.bounds.max.z);
		boundingBox[3] = new Vector3(renderer.bounds.max.x, renderer.bounds.max.y, renderer.bounds.min.z);
		
		bool collisionDetected = false;
		foreach (Vector3 v in boundingBox)
		{
			if ((Mathf.Abs (v.x) > 20) || (Mathf.Abs (v.z) > 23))
			{
				collisionDetected = true;
				break;
			}
		}
		
		if (collisionDetected)
		{
			transform.localPosition = new Vector3 (this.neckPosition.x,
			                                       this.neckPosition.y,
			                                       this.neckPosition.z);		                                      
			transform.localRotation = new Quaternion (this.neckRotation.x,
			                                          this.neckRotation.y,
			                                          this.neckRotation.z,
			                                          this.neckRotation.w);
			transform.localScale = new Vector3 (this.neckScale.x,
			                                    this.neckScale.y,
			                                    this.neckScale.z);
			grabber.transform.localPosition = new Vector3 (this.grabberPosition.x,
			                                               this.grabberPosition.y,
			                                               this.grabberPosition.z);
		}
	}
}
