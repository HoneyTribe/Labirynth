﻿using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	private GameObject gameController;
	private bool move = false;
	private Vector3 vectorToTarget;
	private float distanceToTarget;
	private float dist;
	private float distCovered;
	private float fracJourney;
	private float startTime;
	private float speed = 25.0f;
	private GameObject machine;
	private Transform myTransform;
	private Vector3 myTempPos;
	private bool destroyed = false;
	private bool collected = false;
	private float closeDistance = 0.65f;
	private float arcHeight = 15f;
	private float totalDelta = 0;

	void Start()
	{
		gameController = GameObject.Find ("GameController");
		machine = GameObject.Find ("SpaceMachine");
		myTransform = this.transform.parent;
	}

	void Update()
	{
		if(move == true)
		{
			totalDelta += Time.deltaTime;
			//distCovered = (Time.time - startTime) * speed;
			distCovered = totalDelta * speed;
			fracJourney = distCovered / distanceToTarget;

			myTempPos = myTransform.position;
			myTempPos.x = Mathf.Lerp(myTransform.position.x, machine.transform.position.x, fracJourney)
						+ ( Mathf.Sin(fracJourney * Mathf.PI) * (arcHeight *(myTempPos.x/Mathf.Abs(myTempPos.x))) );
			//straight line Y
			myTempPos.y = Mathf.Lerp(myTransform.position.y, machine.transform.position.y, fracJourney) ;
			//arc Y
			//myTempPos.y = (Mathf.Sin(fracJourney * Mathf.PI * 100) +1) /2 * arcHeight ;
			myTempPos.z = Mathf.Lerp(myTransform.position.z, machine.transform.position.z, fracJourney) ;
			myTransform.position = myTempPos;

			myTransform.position = Vector3.Lerp(myTransform.position, machine.transform.position, fracJourney) ;

			if(fracJourney >= closeDistance && destroyed == false)
			{
				//ScoreController.instance.MinusScore();
				destroyed = true;
				gameController.gameObject.SendMessage("MinusScore");
				Destroy(gameObject.transform.parent.gameObject);
			}
		}
	}
	
	void OnTriggerEnter (Collider currentCollider)
	{
		if ( (currentCollider.tag == "Player") && !currentCollider.gameObject.GetComponent<PlayerController>().isParalysed() 
		    && collected == false)
		{
			collected = true;
			gameController.gameObject.SendMessage("Score");

			vectorToTarget = machine.transform.position - transform.parent.position;
			vectorToTarget.y = 0;
			distanceToTarget = vectorToTarget.magnitude;

			startTime = Time.time;
			move = true;

		}
	}
	
}
