using UnityEngine;
using System.Collections;

public class CraneLightController : MonoBehaviour {

	private static float maxIntensity = 2.3f;

	public float openningInterval = 1.0f;
	public float closingInterval = 0.5f;
	public Material projectorMaterial;
	private float timeLeft = 0.0f;

	private float param;
	private float energyParam;

	private Color newColor;

	void Start()
	{
		newColor = projectorMaterial.color;
		newColor.a = 0.0f;
		projectorMaterial.color = newColor;
	}

	void Update()
	{
		if (timeLeft > 0)
		{
			float lightStep = param * Time.deltaTime;
			GetComponent<Light>().intensity += lightStep;

			float energyStep = energyParam * Time.deltaTime;
			newColor.a += energyStep;
			projectorMaterial.color = newColor;

			timeLeft -= Time.deltaTime;
		}
		else
		{
			if (param < 0)
			{
				GetComponent<Light>().intensity = 0;
			}
			if (energyParam < 0)
			{
				newColor.a = 0;
				projectorMaterial.color = newColor;
			}
		}
	}
	
	void TurnOn ()
	{
		param = maxIntensity / openningInterval;
		energyParam = 1 / openningInterval;
		timeLeft = openningInterval;
	}

	void TurnOff ()
	{
		param = - maxIntensity / closingInterval;
		energyParam = - 1 / closingInterval;
		timeLeft = closingInterval;
	}
}
