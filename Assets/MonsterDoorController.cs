using UnityEngine;
using System.Collections;

public class MonsterDoorController : MonoBehaviour {

	private static float interval = 4.0f;
	private static int delay = 5;
	private static float maxY = 10.0f;
	private static float maxIntensity = 5.0f;

	private float sign;
	private float timeLeft = 0.0f;

	private Vector3 doorInitialPosition;
	public GameObject doorLight;

	void Start()
	{
		doorInitialPosition = transform.localPosition;
	}
	
	void Update()
	{
		if (timeLeft > 0)
		{
			float doorStep = sign * Time.deltaTime * maxY / interval;
			float lightStep = sign * Time.deltaTime * maxIntensity / interval;

			transform.Translate (0, doorStep, 0);
			doorLight.light.intensity += lightStep;
			timeLeft -= Time.deltaTime;
		}
		else
		{
			if (sign < 0)
			{
				transform.localPosition = doorInitialPosition;
				doorLight.light.intensity = 0;
			}
		}

	}
	
	IEnumerator OpenDoor ()
	{
		sign = 1;
		timeLeft = interval;
		yield return new WaitForSeconds(delay);
		sign = -1;
		timeLeft = interval;
	}
}
