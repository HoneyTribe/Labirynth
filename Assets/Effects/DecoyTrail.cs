using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecoyTrail : MonoBehaviour 
{
	//public variables
	public float speed = 25.0f;
	public float mummyOffset = 0.0f;
	public float decoyOffset = 0.0f;
	public float arcHeight = 8f;
	public float closeDistance = 0.4f;
	public float trailDuration = 1.0f;
	public float endDuration = 0.3f;
	//
	private bool resetTime = false;
	private float startTime;
	private float dist;
	private float distCovered;
	private float fracJourney;
	private TrailRenderer trail;
	private LensFlare lens;
	private Transform myTransform;
	private Vector3 myTempPos;
	private Vector3 vectorToTarget;
	private float distanceToTarget;
	private GameObject device;
	private ParticleSystem effect;
	
	void Start()
	{
		device = GameObject.Find ("Device");
		myTransform = this.transform;
		trail = GetComponent<TrailRenderer>();
		lens = GetComponent<LensFlare>();
	}

	void Update()
	{
		if(transform.parent.GetComponent<AbstractMonsterController>().getTimeLeft() > 0 )
		{
			trail.enabled = true;
			lens.enabled = true;
			trail.time = trailDuration;

			if(resetTime == false)
			{
				resetTimer();
			}

			vectorToTarget = device.transform.position - transform.position;
			vectorToTarget.y = 0;
			distanceToTarget = vectorToTarget.magnitude;

			//if(Vector3.Distance(myTransform.position, device.transform.position) > closeDistance)
			if(distanceToTarget > closeDistance)
			{
				distCovered = (Time.time - startTime) * speed;
				fracJourney = distCovered / distanceToTarget;
				//transform.position = Vector3.Lerp(transform.parent.position, device.transform.position, fracJourney) ;

				myTempPos = myTransform.position;
				myTempPos.x = Mathf.Lerp(transform.parent.position.x, device.transform.position.x, fracJourney) ;
				//straight line Y
				//myTempPos.y = Mathf.Lerp(transform.parent.position.y + mummyOffset, device.transform.position.y + decoyOffset, fracJourney) ;
				//arc Y
				myTempPos.y = (Mathf.Sin(fracJourney * Mathf.PI) +1) /2 * arcHeight ;
				myTempPos.z = Mathf.Lerp(transform.parent.position.z, device.transform.position.z, fracJourney) ;
				myTransform.position = myTempPos;
			}
			else
			{
				myTransform.position = transform.parent.position;
				resetTime = false;
			}

		}
		else
		{
			myTransform.position = transform.parent.position;
			trail.time = endDuration;
			StartCoroutine(DisableTrail());
		}
		
	}

	IEnumerator DisableTrail()
		
	{
		yield return new WaitForSeconds(endDuration);
		if(transform.parent.GetComponent<AbstractMonsterController>().getTimeLeft() <= 0 )
		{
			trail.enabled = false;
			lens.enabled = false;
		}
	}
	
	private void resetTimer()
	{
		startTime = Time.time;
		resetTime = true;
	}

}
