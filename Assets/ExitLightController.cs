using UnityEngine;
using System.Collections;

public class ExitLightController : MonoBehaviour {

	public float interval = 1.0f;
	private float timeLeft = 0.0f;
	
	void Update()
	{
		if (timeLeft > 0)
		{
			light.spotAngle += 1.15f;
			light.intensity += 0.075f;
			timeLeft -= Time.deltaTime;
		}
	}
	
	void TurnLightOn ()
	{
		timeLeft = interval;
	}
}
