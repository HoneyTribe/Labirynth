using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunbeamPos : MonoBehaviour 
{
	private GameObject sunbeam_1;
	private GameObject sunbeam_2;
	private GameObject sunbeam_3;

	private Vector3 sunbeam_1Pos;
	private Vector3 sunbeam_2Pos;
	private Vector3 sunbeam_3Pos;
	
	void Start()
	{
		sunbeam_1 = GameObject.Find ("Sunbeam_1");
		sunbeam_2 = GameObject.Find ("Sunbeam_2");
		sunbeam_3 = GameObject.Find ("Sunbeam_3");

		MoveSunbeams();
	}

	private void MoveSunbeams()
	{
		sunbeam_1Pos = sunbeam_1.transform.position;
		sunbeam_1Pos.x = Random.Range(21.5F, 24.5F);
		sunbeam_1Pos.y = Random.Range(55.0F, 63.0F);
		sunbeam_1Pos.z = Random.Range(-12.0F, 20.0F);
		sunbeam_1.transform.position = sunbeam_1Pos;

		sunbeam_2Pos = sunbeam_2.transform.position;
		sunbeam_2Pos.x = Random.Range(-50.0F, 5.0F);
		sunbeam_2.transform.position = sunbeam_2Pos;

		sunbeam_3Pos = sunbeam_3.transform.position;
		sunbeam_3Pos.x = Random.Range(-20.0F, -16.0F);
		sunbeam_3Pos.y = Random.Range(36.0F, 67.0F);
		sunbeam_3Pos.z = Random.Range(-8.0F, 18.0F);
		sunbeam_3.transform.position = sunbeam_3Pos;
	}
	

	
}
