using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DistractLine : MonoBehaviour 
{
	
	public static DistractLine instance;
	
	private GameObject device;
	//private Transform other;

	void Start()
	{
		instance = this;
		device = GameObject.Find ("Device");
	}
	
	void Update()
	{

		float dist = Vector3.Distance(device.transform.position, transform.position);
		//Vector3 dir = (transform.position - device.transform.position).normalized;

		transform.localScale = new Vector3(transform.localScale.x, dist, transform.localScale.z);
		//transform.rotation.y = dir * 10;

		//Vector3 heading = device.transform.position - transform.position;
		//Vector3 distance = heading.magnitude;
		//Vector3 direction = heading / distance;

		//transform.localScale = new Vector3(transform.localScale.x, distance, transform.localScale.z);
		//transform.rotation.y = direction;





	}
}
