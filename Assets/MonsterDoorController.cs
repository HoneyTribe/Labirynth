using UnityEngine;
using System.Collections;

public class MonsterDoorController : MonoBehaviour {

	public float interval = 1.0f;
	private float timeLeft = 0.0f;
	private int delay = 5;
	private float doorStep;
	private float lightStep;
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
			transform.Translate (0, doorStep, 0);
			doorLight.light.intensity += lightStep;
			timeLeft -= Time.deltaTime;
		}
		else
		{
			if (doorStep < 0 || lightStep < 0)
			{
				transform.localPosition = doorInitialPosition;
				doorLight.light.intensity = 0;
				doorStep = 0;   // reset
				lightStep = 0;  // reset
			}
		}

	}
	
	IEnumerator OpenDoor ()
	{
		doorStep = 0.3f;
		lightStep = 0.15f;
		timeLeft = interval;
		yield return new WaitForSeconds(delay);
		doorStep = -0.3f;
		lightStep = -0.15f;
		timeLeft = interval;
	}
}
