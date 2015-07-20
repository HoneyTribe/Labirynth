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
	private bool startTrigger = false;
	
	void Start()
	{
		anim = GameObject.Find ("ControlPadPop").GetComponent<Animator> ();
		anim2 = GameObject.Find ("ControlPadPopTrigger").GetComponent<Animator> ();
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

	private void FadeInTrigger()
	{
		if(startTrigger == false)
		{
			startTrigger = true;
			anim2.SetTrigger(fadeInHash);
		}
	}

	void Update()
	{
		if(IntroductionController.instance.isPlayingIntroduction()== false && startTrigger == false)
		{
			FadeInTrigger();
		}
	}
}
