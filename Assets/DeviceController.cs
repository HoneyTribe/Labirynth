using UnityEngine;
using System.Collections;

public class DeviceController : MonoBehaviour {

	private Vector3 initialPosition;

	private Vector3 movement;
	private bool isInLighhouse = true;
	private float speed = 10.0f;

	void Start () 
	{
		initialPosition = transform.localPosition;
		movement = initialPosition;
	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance(transform.position, movement);
		if (distance > 0)
		{
			transform.position = Vector3.Lerp (
				transform.position, movement, Time.deltaTime * speed / distance);
		}
	}

	public void Move(Vector3 positionToMove)
	{
		if (isInLighhouse)
		{
			isInLighhouse = false;
			movement = new Vector3(positionToMove.x, 1, positionToMove.z);
		}
		else
		{
			isInLighhouse = true;
			movement = initialPosition;
		}
	}
}
