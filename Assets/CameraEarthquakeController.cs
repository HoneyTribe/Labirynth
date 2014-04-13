using UnityEngine;
using System.Collections;

public class CameraEarthquakeController : MonoBehaviour {

	public float startingShakeDistance = 0.8f;
	public float decreasePercentage = 0.5f;
	public float shakeSpeed = 50f;
	public int numberOfShakes = 10;
		
	private Vector3 originalPosition;
	private int shake;
	private float shakeDistance;
	private float hitTime;

	void Start()
	{
		originalPosition = camera.transform.position;
		//StartCoroutine(StartEarthquakeTimer());
	}

	public void StartEarthquake()
	{
		shakeDistance = startingShakeDistance;
		hitTime = Time.time;
		shake = numberOfShakes;
	}

	IEnumerator StartEarthquakeTimer() 
	{
		while (true)
		{
			int delay = Random.Range (30, 40);
			yield return new WaitForSeconds (delay);
			shakeDistance = startingShakeDistance;
			hitTime = Time.time;
			shake = numberOfShakes;
		}
	}

	void Update()
	{
		if (shake > 0)
		{
			float timer = (Time.time - hitTime) * shakeSpeed;
			camera.transform.position = new Vector3(originalPosition.x + Mathf.Sin(timer) * shakeDistance,
			                                        originalPosition.y,
			                                        originalPosition.z);

			if (timer > Mathf.PI * 2)
			{
				hitTime = Time.time;
				shakeDistance *= decreasePercentage;
				shake--;
			}
		}

		if (shake == 0)
		{
			camera.transform.position = originalPosition;
			shake--;
		}
	}
}
