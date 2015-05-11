using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimePortalController : MonoBehaviour {

	public static TimePortalController instance;

	private static int activatedHash = Animator.StringToHash ("Activate");

	private Animator anim;
	private Animator transition;

	void Start()
	{
		instance = this;
		anim = GameObject.Find ("Portal_").GetComponent<Animator> ();
		transition = GameObject.Find ("TransitionTemp").GetComponent<Animator>();
	}

	public IEnumerator startTimePortal()
	{
		this.anim.SetTrigger(activatedHash);
		AudioController.instance.Play("026_FusionB");
		LevelFinishedController.instance.setStopped (true);
		yield return new WaitForSeconds(3);
		this.transition.enabled = true;
		yield return new WaitForSeconds(3);
		Application.LoadLevel (1);
	}
}
