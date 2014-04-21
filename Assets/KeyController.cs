﻿using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	private GameObject gameController;

	void Start()
	{
		gameController = GameObject.Find ("GameController");
	}
	
	void OnTriggerEnter (Collider currentCollider)
	{
		if ((!currentCollider.name.Contains("Monster")) && (currentCollider.name != "Grabber") && (currentCollider.tag != "Item"))
		{
			Destroy(gameObject);
			gameController.gameObject.SendMessage("Score");
		}
	}
}
