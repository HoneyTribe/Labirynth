using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextBarrier2 : MonoBehaviour 
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
			text_enter.GetComponentInChildren<TextMesh>().text = "press 'start' or 'enter' when all players are ready";
		}
	}
}
