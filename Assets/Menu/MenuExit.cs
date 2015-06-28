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
	private Animator anim;
	private static int OnHash = Animator.StringToHash ("On");
	private static int OffHash = Animator.StringToHash ("Off");
	private bool animOn;
	private bool savedAnimOn;
	
	
	void Start ()
	{
		instance = this;
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
		text_enter = GameObject.Find ("Text_Enter");
		anim = GameObject.Find ("ExitPopUp").GetComponent<Animator>();
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
			if (playersInside == 1)
			{
				animOn = true;
				text_enter.GetComponentInChildren<TextMesh>().text = "To exit the game press 'start'/'enter'";
				TriggerAnimOpen();
			}
		}
	}
	
	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInside--;
			if (playersInside == 0)
			{
				animOn = false;
				text_enter.GetComponentInChildren<TextMesh>().text = "2-4 characters must enter the portal";
				TriggerAnimClose();
			}
		}
	}
	
	private void TriggerAnimOpen()
	{
		if (animOn == true && savedAnimOn == false)
		{
			savedAnimOn = true;
			anim.SetTrigger(OnHash);
		}
	}
	
	private void TriggerAnimClose()
	{
		if (animOn == false && savedAnimOn == true)
		{
			savedAnimOn = false;
			anim.SetTrigger(OffHash);
		}
	}

	public int getplayersInside()
	{
		return playersInside;
	}
	
	
}
