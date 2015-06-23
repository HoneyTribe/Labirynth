﻿using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour
{
	private GameObject myCamera;
	private Quaternion myTempRotation;

	void Start()
	{
		myCamera = GameObject.Find ("MainCamera_Front");
		transform.renderer.enabled = false;

	}

	public void activateHelp()
	{
		transform.LookAt(transform.position + myCamera.transform.rotation * Vector3.up, myCamera.transform.rotation * Vector3.back);
		myTempRotation = transform.rotation;
		myTempRotation.y = 180;
		transform.rotation = myTempRotation;
		transform.renderer.enabled = true;
	}

	public void deactivateHelp()
	{
		transform.renderer.enabled = false;
	}

}
