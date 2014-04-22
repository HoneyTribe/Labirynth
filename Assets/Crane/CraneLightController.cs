using UnityEngine;
using System.Collections;

public class CraneLightController : MonoBehaviour {

	private static float maxIntensity = 5f;

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

	void ActivateItems()
	{
		if (CraneEnergyController.instance.canActivate())
		{
			bool itemActivated = false;
			GameObject[] items = GameObject.FindGameObjectsWithTag ("Item");
			foreach (GameObject item in items)
			{
				if (isIlluminated(item))
				{
					JumpController jumpController = item.GetComponent<JumpController>();
					if (jumpController.hasAnyObjects())
					{
						jumpController.Activate();
						//StartCoroutine(showLaser(item.transform.localPosition));
						itemActivated = true;
					}
				}
			}
			
			if (itemActivated)
			{
				CraneEnergyController.instance.activating();
			}
		}
	}
	
	private bool isIlluminated(GameObject obj)
	{
		Vector3 objectDirection = new Vector3(obj.transform.localPosition.x - transform.position.x,
		                                      obj.transform.localPosition.y - transform.position.y,
		                                      obj.transform.localPosition.z - transform.position.z).normalized;
		float angle = Vector3.Angle(Vector3.down, objectDirection);
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
