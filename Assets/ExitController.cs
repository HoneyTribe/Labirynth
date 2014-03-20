using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour {

	public float interval = 2.0f;
	private float timeLeft = 0.0f;
	
	void Update()
	{
		if (timeLeft > 0)
		{
			transform.Translate (0, 0.31f, 0);
			timeLeft -= Time.deltaTime;
		}
	}

	void OpenDoor ()
	{
		timeLeft = interval;
	}
}
