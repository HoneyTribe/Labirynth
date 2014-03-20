using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour {

	private static float maxY = 15.0f;

	public float interval = 2.0f;
	private float timeLeft = 0.0f;
	
	void Update()
	{
		if (timeLeft > 0)
		{
			float doorStep = Time.deltaTime * maxY / interval;
			transform.Translate (0, doorStep, 0);
			timeLeft -= Time.deltaTime;
		}
	}

	void OpenDoor ()
	{
		timeLeft = interval;
	}
}
