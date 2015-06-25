using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZapShoot : MonoBehaviour 
{
	//public variables
	private float speed = 350.0f;
	private float mummyOffset = 3.0f;
	private float decoyOffset = 0.0f;
	private float arcHeight = 6f;
	private float closeDistance = 2.0f;
	private float trailDuration = 1.0f;
	private float endDuration = 0.3f;
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
	private SpawnDecoyTrail spawnDecoyTrail;
	
	private Vector3 startPos;
	private Vector3 endPos;
	private Vector3 currentPos;
	
	private Vector3 myTempScale;
	
	private Vector3 pos;
	private float destroyDuration = 0.3f;
		
		void Start()
	{
		//device = GameObject.Find ("Device");
		//myTransform = this.transform;
		//trail = GetComponent<TrailRenderer>();
		//lens = GetComponent<LensFlare>();
		//spawnDecoyTrail = transform.parent.GetComponent<SpawnDecoyTrail>();
		
		
	}
	
	public void shoot (Vector3 startPosition, Vector3 endPosition)
	{
		startPos = startPosition;
		endPos = endPosition;
		//currentPos = startPos;
		
		vectorToTarget = endPos - startPos;
		vectorToTarget.y = 0;
		distanceToTarget = vectorToTarget.magnitude;
		
		
		//myTempScale = new Vector3(transform.localScale.x, transform.localScale.y, distanceToTarget);
		//transform.localScale = myTempScale;
		
		
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, distanceToTarget);
		transform.LookAt(endPos);
		
		pos = startPos + (endPos - startPos) / 2;
		transform.position = pos;
		StartCoroutine(Destroy());
		
		//startTime = Time.time;
		
		
	}
	
	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(destroyDuration);
		Destroy(gameObject);
	}
	
	/*
	void Update()
	{

			//trail.enabled = true;
			//lens.enabled = true;
			//trail.time = trailDuration;
			
			//if(Vector3.Distance(myTransform.position, device.transform.position) > closeDistance)
			
			distCovered = (Time.time - startTime) * speed;
			fracJourney = distCovered / distanceToTarget;
			//transform.position = Vector3.Lerp(transform.position, endPos, fracJourney) ;
				
				//myTempPos = myTransform.position;
				//myTempPos.x = Mathf.Lerp(transform.position.x, endPos.transform.position.x, fracJourney) ;
				//straight line Y
				//myTempPos.y = Mathf.Lerp(transform.position.y + mummyOffset, endPos.transform.position.y + decoyOffset, fracJourney) ;
				//arc Y
				//myTempPos.y = (Mathf.Sin(fracJourney * Mathf.PI) +1) /2 * arcHeight ;
				//myTempPos.z = Mathf.Lerp(transform.parent.position.z, device.transform.position.z, fracJourney) ;
				//myTransform.position = myTempPos;
	}


	public void OnTriggerEnter(Collider currentCollider)
	{
		if ( (currentCollider.tag == "Monster") )
		{
			//Destroy(gameObject);
		}
	}
	*/
}