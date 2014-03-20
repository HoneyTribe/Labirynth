using UnityEngine;
using System.Collections;

public class CandleLightController : MonoBehaviour {

	private float maxIntensity;

	public float interval = 1.0f;
	private float timeLeft = 0.0f;

	void Start()
	{
		maxIntensity = light.intensity;
	}

	void Update()
	{
		if (timeLeft > 0)
		{
			light.intensity -= Time.deltaTime * maxIntensity / interval;
			timeLeft -= Time.deltaTime;
		}
		else
		{
			if (light.intensity < maxIntensity)
			{
				light.intensity = 0;
			}
		}
	}
	
	void TurnLightOn ()
	{
		timeLeft = interval;
	}
}
