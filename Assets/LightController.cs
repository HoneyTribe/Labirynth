using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	private float rotationSpeed = 0.5f;

	void MoveLeft()
	{
		if (transform.rotation.y > -0.40) 
		{
			transform.Rotate (0, -rotationSpeed, 0);
		}
	}

	void MoveRight()
	{
		if (transform.rotation.y < 0.40) 
		{
			transform.Rotate (0, rotationSpeed, 0);
		}
	}
}
