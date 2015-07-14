using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlPadPopTrigger : MonoBehaviour 
{
	
	private static int openHash = Animator.StringToHash ("Open");
	private static int closeHash = Animator.StringToHash ("Close");
	private static int fadeInHash = Animator.StringToHash ("FadeIn");
	private static int fadeOutHash = Animator.StringToHash ("FadeOut");
	private Animator anim;
	private Animator anim2;
	//private Vector3 startPos;
	//private Vector3 endPos;
	//private bool goUp;
	
	void Start()
	{
		anim = GameObject.Find ("ControlPadPop").GetComponent<Animator> ();
		anim2 = GameObject.Find ("ControlPadPopTrigger").GetComponent<Animator> ();

		// lev 4, first decoy
		//if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDecoyLevel)
		//{
			//startPos = new Vector3(-10,1,-7);
			//endPos = new Vector3(-10,5,-7);
			//transform.position = startPos;

		//}
	}
	
	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			anim.SetTrigger(openHash);
			anim2.SetTrigger(fadeOutHash);
		}
	}
	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			anim.SetTrigger(closeHash);
			anim2.SetTrigger(fadeInHash);
		}
	}
	/*
	void Update()
	{
		if(transform.position.y <= startPos.y)
		{
			goUp = true;
		}

		if(transform.position.y >= endPos.y)
		{
			goUp = false;
		}

		if(goUp == true)
		{
			transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime);
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, startPos , Time.deltaTime);
		}
	}
	*/
}
