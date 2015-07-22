using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZapShoot : MonoBehaviour 
{

	private float destroyDuration = 0.25f;

	void Start()
	{
		StartCoroutine(Destroy());
	}

	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(destroyDuration);
		Destroy(gameObject);
	}

}