using UnityEngine;
using System.Collections;

public class TopLightController : MonoBehaviour {

	public float interval = 1.0f;
	private float timeLeft = 0.0f;
	private float step;
	
	void Update()
	{
		if (timeLeft > 0)
		{
			light.intensity += step;
			timeLeft -= Time.deltaTime;
		}
	}
	
	void TurnOn ()
	{
		step = 0.023f;
		timeLeft = interval;
	}

	void TurnOff ()
	{
		step = -0.023f;
		timeLeft = interval;
	}
}
