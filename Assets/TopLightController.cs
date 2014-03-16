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
