using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlPadPopTrigger : MonoBehaviour 
{
	
	private static int openHash = Animator.StringToHash ("Open");
	private static int closeHash = Animator.StringToHash ("Close");
	private GameObject controlPadPop;
	private Animator anim;
	
	void Start()
	{
		//controlPadPop = GameObject.Find ("ControlPadPop");
		anim = GameObject.Find ("ControlPadPop").GetComponent<Animator> ();
	}
	
	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			anim.SetTrigger(openHash);
		}
	}
	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			anim.SetTrigger(closeHash);
		}
	}
}
