using UnityEngine;
using System.Collections;

public class CandleLightController : MonoBehaviour {

	public float interval = 1.0f;
	private float timeLeft = 0.0f;
	
	void Update()
	{
		if (timeLeft > 0)
		{
			light.intensity -= 0.04f;
			timeLeft -= Time.deltaTime;
		}
	}
	
	void TurnLightOn ()
	{
		timeLeft = interval;
	}
}
