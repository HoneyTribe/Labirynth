using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuExit : MonoBehaviour
{
	public static MenuExit instance;
	private float x;
	private float y;
	private float z;
	private GameObject text_enter;
	private int playersInside = 0;
	
	
	void Start ()
	{
		instance = this;
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
		text_enter = GameObject.Find ("Text_Enter");
		position();
	}

	
	private void position()
	{
		if(LevelFinishedController.instance.getHomeVersion() == 1 )
		{
		transform.position = new Vector3(x, y, z);
		}
		else // exhibition version
		{
		transform.position = new Vector3(x, -10, z);
		}
	}
	
	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInside++;
			text_enter.GetComponentInChildren<TextMesh>().text = "Press 'start'/'enter' to exit the game";
		}
	}
	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInside--;
			if (playersInside == 0)
			{
			text_enter.GetComponentInChildren<TextMesh>().text = "2-4 characters must enter the portal";
			}
		}
	}
	
	public int getplayersInside()
	{
		return playersInside;
	}
	
	
}
