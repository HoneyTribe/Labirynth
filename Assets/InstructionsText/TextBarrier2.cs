using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextBarrier2 : MonoBehaviour 
{
	
	public static TextBarrier2 instance;

	private GameObject text_enter;
	private int playersInPortal = 0;
	
	void Start()
	{
		instance = this;
		text_enter = GameObject.Find ("Text_Enter");
	}
	
	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInPortal++;
			if(playersInPortal >=2)
			{
			text_enter.GetComponentInChildren<TextMesh>().text = "press 'start'/'enter' when everybody is ready";
			}
		}
	}

	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInPortal--;
		}
	}

	public int getPlayersInPortal()
	{
		return playersInPortal;
	}
}
