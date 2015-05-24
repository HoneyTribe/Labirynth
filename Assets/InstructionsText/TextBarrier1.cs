using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextBarrier1 : MonoBehaviour 
{

	public static TextBarrier1 instance;
	private static int activatedHash = Animator.StringToHash ("Activate");
	private static int activateHash = Animator.StringToHash ("FadeIn");
	private GameObject text_enter;
	private Animator anim1;
	private Animator anim2;
	private Animator anim3;
	private Animator anim4;
	private Animator anim0;

	void Start()
	{
		instance = this;
		text_enter = GameObject.Find ("Text_Enter");
		anim0 = GameObject.Find ("Portal_").GetComponent<Animator> ();
		anim1 = GameObject.Find ("Puzzle_1").GetComponent<Animator> ();
		anim2 = GameObject.Find ("Puzzle_2").GetComponent<Animator> ();
		anim3 = GameObject.Find ("Puzzle_3").GetComponent<Animator> ();
		anim4 = GameObject.Find ("Puzzle_4").GetComponent<Animator> ();
	}

	//public IEnumerator PortalOn()
	//{
	//	yield return new WaitForSeconds(1.0f);
	//	this.anim0.SetTrigger(activatedHash);
	//}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			text_enter.GetComponentInChildren<TextMesh>().text = "2-4 characters must enter the portal";
			this.anim1.SetTrigger(activatedHash);
			this.anim2.SetTrigger(activatedHash);
			this.anim3.SetTrigger(activatedHash);
			this.anim4.SetTrigger(activatedHash);
			this.anim0.SetTrigger(activateHash);
		}
	}
}
