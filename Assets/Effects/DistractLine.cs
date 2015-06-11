using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DistractLine : MonoBehaviour 
{
	
	//public static DistractLine instance;
	
	private GameObject device;
	private ParticleSystem effect;

	void Start()
	{
		//instance = this;
		device = GameObject.Find ("Device");
		effect = transform.particleSystem;
	}
	
	void Update()
	{
		if(transform.parent.GetComponent<AbstractMonsterController>().getTimeLeft() > 0 )
		{
			effect.enableEmission = true;

			float dist = Vector3.Distance(device.transform.position, transform.parent.position);
			Vector3 pos = transform.parent.position + (device.transform.position - transform.parent.position) / 2;

			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, dist * 0.5f);
			transform.position = new Vector3(pos.x, pos.y, pos.z);
			transform.LookAt(transform.parent);
		}
		else
		{
			//transform.position = new Vector3(0, -10, 0);
			effect.enableEmission = false;
		}

	}
}
