﻿using UnityEngine;
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
		newRange = GetComponent<Light>().range;
	}

	void Update()
	{
		float rangeDiff = newRange - GetComponent<Light>().range;
		if (rangeDiff != 0)
		{
			GetComponent<Light>().range = Mathf.Lerp(GetComponent<Light>().range, newRange, Time.deltaTime * rangeSpeed / rangeDiff);
		}

		float intensityDiff = newIntensity - GetComponent<Light>().intensity;
		if (intensityDiff != 0)
		{
			GetComponent<Light>().intensity = Mathf.Lerp(GetComponent<Light>().intensity, newIntensity, Time.deltaTime * intensitySpeed / intensityDiff);
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
		GetComponent<Light>().cullingMask = (1 << LayerMask.NameToLayer ("mazeWalls")) |
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
		rangeSpeed = (50.0f - GetComponent<Light>().range) / 1.5f;

		yield return new WaitForSeconds(1);

		newPosition = new Vector3(gameObject.transform.localPosition.x,
		                          07,
		                          18);
		positionSpeed = (10 - gameObject.transform.localPosition.y) * 2.0f;

		newRange = 40;
		rangeSpeed = (40 - GetComponent<Light>().range) / 2.0f;

		newIntensity = 0.4f;
		intensitySpeed = (1 - GetComponent<Light>().intensity) * 5.0f;
	}
}
