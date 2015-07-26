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
	private Animator animUpdate;

	void Start()
	{
		instance = this;
		text_enter = GameObject.Find ("Text_Enter");
		anim0 = GameObject.Find ("Portal_").GetComponent<Animator> ();
		anim1 = GameObject.Find ("Puzzle_1").GetComponent<Animator> ();
		anim2 = GameObject.Find ("Puzzle_2").GetComponent<Animator> ();
		anim3 = GameObject.Find ("Puzzle_3").GetComponent<Animator> ();
		anim4 = GameObject.Find ("Puzzle_4").GetComponent<Animator> ();
		animUpdate = GameObject.Find ("Update_Button_01").GetComponent<Animator> ();
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
			text_enter.GetComponentInChildren<TextMesh>().text = "Enter the portal";
			anim1.SetTrigger(activatedHash);
			anim2.SetTrigger(activatedHash);
			anim3.SetTrigger(activatedHash);
			anim4.SetTrigger(activatedHash);
			anim0.SetTrigger(activateHash);
			animUpdate.SetTrigger(activatedHash);
		}
	}
}
