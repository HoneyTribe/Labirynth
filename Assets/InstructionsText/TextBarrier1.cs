using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextBarrier1 : MonoBehaviour 
{

	private GameObject text_enter;

	void Start()
	{
		text_enter = GameObject.Find ("Text_Enter");
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			text_enter.GetComponentInChildren<TextMesh>().text = "2-4 characters must enter the portal";
		}
	}
}
