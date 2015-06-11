using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecoyTrail : MonoBehaviour 
{
	
	//public static DistractLine instance;
	
	private GameObject device;
	private ParticleSystem effect;
	private float speed = 20.0f;
	private bool resetTime = false;
	private float startTime;
	private int closeDistance = 1;
	
	void Start()
	{
		//instance = this;
		device = GameObject.Find ("Device");
		//effect = transform.particleSystem;
	}
	
	void Update()
	{
		if(transform.parent.GetComponent<AbstractMonsterController>().getTimeLeft() > 0 )
		{
			transform.position = transform.parent.position;
			//effect.enableEmission = true;

			if(resetTime == false)
			{
				resetTimer();
			}

			if(Vector3.Distance(transform.position, device.transform.position) > closeDistance)
			{
				float dist = Vector3.Distance(device.transform.position, transform.parent.position);
				float distCovered = (Time.time - startTime) * speed;
				float fracJourney = distCovered / dist;

				transform.position = Vector3.Lerp(transform.parent.position, device.transform.position, fracJourney);
			}
			if(Vector3.Distance(transform.position, device.transform.position) <= closeDistance)
			{
				transform.position = transform.parent.position;
				//transform.position = new Vector3(0,0,0);
				resetTime = false;
			}
			
			//float dist = Vector3.Distance(device.transform.position, transform.parent.position);
			//Vector3 pos = transform.parent.position + (device.transform.position - transform.parent.position) / 2;
			
			//transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, dist * 0.5f);
			//transform.position = new Vector3(pos.x, pos.y, pos.z);
			//transform.LookAt(transform.parent);
		}
		else
		{
			//transform.position = new Vector3(0, -10, 0);
			//effect.enableEmission = false;
		}
		
	}

	private void resetTimer()
	{
		startTime = Time.time;
		resetTime = true;
	}
}
