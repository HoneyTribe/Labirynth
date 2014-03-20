using UnityEngine;
using System.Collections;

public class TopLightController : MonoBehaviour {

	private static float maxIntensity = 1.0f;

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

	void AttractMonster()
	{
		GameObject[] monsters = GameObject.FindGameObjectsWithTag ("Monster");
		foreach (GameObject monster in monsters)
		{
			if (isIlluminated(monster))
			{
				monster.GetComponent<MonsterController>().setAttracted();
			}
		}
		
	}
	
	private bool isIlluminated(GameObject monster)
	{
		Quaternion quat = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up);
		Vector3 lightDirection = new Vector3(0, 0, 1);		
		lightDirection = quat * lightDirection;
		
		Vector3 monsterDirection = new Vector3(monster.transform.localPosition.x - transform.position.x,
		                                       0,
		                                       monster.transform.localPosition.z - transform.position.z).normalized;
		float angle = Vector3.Angle(lightDirection, monsterDirection);
		if ((light.intensity > 0) && (angle < light.spotAngle/2f))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
