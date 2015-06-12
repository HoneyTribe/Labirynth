using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecoyTrail : MonoBehaviour 
{

	//public static DistractLine instance;
	
	private GameObject device;
	private ParticleSystem effect;
	public float speed = 25.0f;
	private bool resetTime = false;
	private float startTime;
	public float closeDistance = 0.1f;
	public float mummyOffset = 3.0f;
	public float decoyOffset = 0.0f;
	public float constant = 2.0f;
	public float trailDuration = 2.0f;
	public float endDuration = 0.2f;
	Transform myTransform;
	private TrailRenderer trail;
	//Transform parentTransform;
	//Transform deviceTransform;
	Vector3 myTempPos;
	
	void Start()
	{
		//instance = this;
		device = GameObject.Find ("Device");
		myTransform = this.transform;
		trail = GetComponent<TrailRenderer>();
		//effect = transform.particleSystem;
	}

	void Update()
	{
		if(transform.parent.GetComponent<AbstractMonsterController>().getTimeLeft() > 0 )
		{

			//trail.enabled = true;
			trail.time = trailDuration;
			if(resetTime == false)
			{
				resetTimer();
			}

			if(Vector3.Distance(myTransform.position, device.transform.position) > closeDistance)
			{
				float dist = Vector3.Distance(device.transform.position, transform.parent.position);
				float distCovered = (Time.time - startTime) * speed;
				float fracJourney = distCovered / dist;

				//this works// transform.position = Vector3.Lerp(transform.parent.position, device.transform.position, fracJourney) ;

				myTempPos = myTransform.position;
				myTempPos.x = Mathf.Lerp(transform.parent.position.x, device.transform.position.x, fracJourney) ;
				myTempPos.y = Mathf.Lerp(transform.parent.position.y + mummyOffset, device.transform.position.y + decoyOffset, fracJourney) ;
				//myTempPos.y = (Mathf.Sin(constant * (Time.time - startTime) * Mathf.PI)+ 1) / 2 + mummyOffset;
				myTempPos.z = Mathf.Lerp(transform.parent.position.z, device.transform.position.z, fracJourney) ;
				myTransform.position = myTempPos;
			}
			if(Vector3.Distance(myTransform.position, device.transform.position) <= closeDistance)
			{
				myTransform.position = transform.parent.position;
				resetTime = false;
			}

		}
		else
		{
			myTransform.position = transform.parent.position;
			//trail.enabled = false;
			trail.time = endDuration;
		}
		
	}

	private void resetTimer()
	{
		startTime = Time.time;
		resetTime = true;
	}

}
