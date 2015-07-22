﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecoyTrail : MonoBehaviour 
{
	private float speed = 250.0f;
	private float mummyOffset = 3.0f;
	private float decoyOffset = 3.0f;
	private float arcHeight = 8f;
	private float closeDistance = 0.1f;
	private float trailDuration = 0.5f;
	private float endDuration = 0.2f;
	//private float lensFadeSpeed = 0.0f;
	//
	private bool resetTime = false;
	private float startTime;
	private float dist;
	private float distCovered;
	private float fracJourney;
	private TrailRenderer trail;
	//private LensFlare lens;
	private Transform myTransform;
	private Vector3 myTempPos;
	private Vector3 vectorToTarget;
	private float distanceToTarget;
	private GameObject device;
	private ParticleSystem effect;
	private float totalDelta = 0;
	
	void Start()
	{
		device = GameObject.Find ("DeviceContainer");
		myTransform = this.transform;
		trail = GetComponent<TrailRenderer>();
		//lens = GetComponent<LensFlare>();
		trail.time = trailDuration;
		//lens.fadeSpeed = lensFadeSpeed;
	}

	void Update()
	{
		if(transform.parent.GetComponent<AbstractMonsterController>().getTimeLeft() > 0 && LevelFinishedController.instance.isStopped()==false)
		{
			totalDelta += Time.deltaTime;

			trail.enabled = true;
			//lens.enabled = true;


			if(resetTime == false)
			{
				resetTimer();
			}

			vectorToTarget = device.transform.position - transform.position;
			vectorToTarget.y = 0;
			distanceToTarget = vectorToTarget.magnitude;

			if(distanceToTarget > closeDistance)
			{
				//distCovered = (Time.time - startTime) * speed;
				distCovered = totalDelta * speed;
				fracJourney = distCovered / distanceToTarget;
				//transform.position = Vector3.Lerp(transform.parent.position, device.transform.position, fracJourney) ;

				myTempPos = myTransform.position;
				myTempPos.x = Mathf.Lerp(transform.parent.position.x, device.transform.position.x, fracJourney * Time.deltaTime) ;
				//straight line Y
				myTempPos.y = Mathf.Lerp(transform.parent.position.y + mummyOffset, device.transform.position.y + decoyOffset, fracJourney * Time.deltaTime) ;
				//arc Y
				//myTempPos.y = (Mathf.Sin(fracJourney * Mathf.PI) +1) /2 * arcHeight ;
				myTempPos.z = Mathf.Lerp(transform.parent.position.z, device.transform.position.z, fracJourney * Time.deltaTime) ;
				myTransform.position = myTempPos;
			}
			else
			{
				myTempPos = transform.parent.position;
				myTempPos.y += mummyOffset;
				myTransform.position = myTempPos;
				resetTime = false;
			}

		}
		else
		{
			myTempPos = transform.parent.position;
			myTempPos.y += mummyOffset;
			myTransform.position = myTempPos;
			trail.time = endDuration;
			//lens.fadeSpeed = endDuration;
			StartCoroutine(DisableTrail());
		}
		
	}

	IEnumerator DisableTrail()
		
	{
		yield return new WaitForSeconds(endDuration);
		if(transform.parent.GetComponent<AbstractMonsterController>().getTimeLeft() <= 0 )
		{
			trail.enabled = false;
			totalDelta = 0;
			//lens.enabled = false;
		}
	}
	
	private void resetTimer()
	{
		resetTime = true;
		startTime = Time.time;
		trail.time = trailDuration;
		totalDelta = 0;
		//lens.fadeSpeed = lensFadeSpeed;
	}

}
