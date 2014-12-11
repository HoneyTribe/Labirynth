using UnityEngine;
using System.Collections;

public class FusionLightController : MonoBehaviour {

	private Vector3 newPosition;
	private float positionSpeed;

	private float newRange;
	private float rangeSpeed;

	private float newIntensity;
	private float intensitySpeed;

	void Start()
	{
		newPosition = gameObject.transform.localPosition;
		newRange = light.range;
	}

	void Update()
	{
		float rangeDiff = newRange - light.range;
		if (rangeDiff != 0)
		{
			light.range = Mathf.Lerp(light.range, newRange, Time.deltaTime * rangeSpeed / rangeDiff);
		}

		float intensityDiff = newIntensity - light.intensity;
		if (intensityDiff != 0)
		{
			light.intensity = Mathf.Lerp(light.intensity, newIntensity, Time.deltaTime * intensitySpeed / intensityDiff);
		}

		float distance = Vector3.Distance(gameObject.transform.localPosition, newPosition);
		if (distance != 0)
		{			
			transform.localPosition = Vector3.Lerp (
				transform.localPosition, newPosition, Time.deltaTime * positionSpeed / distance);
		}
	}
	
	public IEnumerator TurnLightOn ()
	{
		light.cullingMask = (1 << LayerMask.NameToLayer ("mazeWalls")) |
							(1 << LayerMask.NameToLayer ("1stRowMazeWalls")) |
							(1 << LayerMask.NameToLayer ("outsideWalls")) |
							(1 << LayerMask.NameToLayer ("ground")) |
							(1 << LayerMask.NameToLayer ("exitDoors")) |
							(1 << LayerMask.NameToLayer ("monsterDoors")) |
							(1 << LayerMask.NameToLayer ("players")) |
							(1 << LayerMask.NameToLayer ("monsters")) |
							(1 << LayerMask.NameToLayer ("lighthouse")) |
							(1 << LayerMask.NameToLayer ("Details")) |
							(1 << LayerMask.NameToLayer ("FrontWalls")) |
							(1 << LayerMask.NameToLayer ("flyingMonsters")) |
							(1 << LayerMask.NameToLayer ("Sand")) |
							(1 << LayerMask.NameToLayer ("1stOutsideWalls"));

		newPosition = new Vector3(gameObject.transform.localPosition.x,
		                          -5.0f,
		                          gameObject.transform.localPosition.z);
		positionSpeed = (-5.0f - gameObject.transform.localPosition.y) / 1.5f;

		newRange = 50.0f;
		rangeSpeed = (50.0f - light.range) / 1.5f;

		yield return new WaitForSeconds(1);

		newPosition = new Vector3(gameObject.transform.localPosition.x,
		                          07,
		                          18);
		positionSpeed = (10 - gameObject.transform.localPosition.y) / 2.0f;

		newRange = 40;
		rangeSpeed = (40 - light.range) / 2.0f;

		newIntensity = 1;
		intensitySpeed = (1 - light.intensity) / 2.0f;
	}
}
