using UnityEngine;
using System.Collections;

public class ExitLightController : MonoBehaviour {

	private static float maxInstensity = 3.0f;
	private static float maxSpot = 60.0f;

	public float interval = 1.0f;
	private float timeLeft = 0.0f;
	
	void Update()
	{
		if (timeLeft > 0)
		{
			float intensityStep = Time.deltaTime * maxInstensity / interval;
			float spotStep = Time.deltaTime * maxSpot / interval;
			light.spotAngle += spotStep;
			light.intensity += intensityStep;
			timeLeft -= Time.deltaTime;
		}
	}
	
	void TurnLightOn ()
	{
		timeLeft = interval;
	}
}
