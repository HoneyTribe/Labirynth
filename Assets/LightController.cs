﻿using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	public static LightController instance;

	private float rotationSpeed = 18f;

	void Start()
	{
		rotationSpeed *= LevelFinishedController.instance.gameSpeed;
		instance = this;
	}

	void MoveLeft()
	{
		if (transform.rotation.y > -0.45) 
		{
			transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		}
	}

	void MoveRight()
	{
		if (transform.rotation.y < 0.45) 
		{
			transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		}
	}
}
