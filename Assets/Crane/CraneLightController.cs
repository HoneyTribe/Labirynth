using UnityEngine;
using System.Collections;

public class CraneLightController : MonoBehaviour {

	private static float maxIntensity = 5f;

	public float openningInterval = 1.0f;
	public float closingInterval = 0.5f;
	private float timeLeft = 0.0f;

	private float param;

	void Update()
	{
		if (timeLeft > 0)
		{
			float lightStep = param * Time.deltaTime;

			light.intensity += lightStep;
			timeLeft -= Time.deltaTime;
		}
		else
		{
			if (param < 0)
			{
				light.intensity = 0;
			}
		}
	}
	
	void TurnOn ()
	{
		param = maxIntensity / openningInterval;
		timeLeft = openningInterval;
	}

	void TurnOff ()
	{
		param = - maxIntensity / closingInterval;
		timeLeft = closingInterval;
	}
}
