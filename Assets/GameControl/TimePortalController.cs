using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimePortalController : MonoBehaviour {

	public static TimePortalController instance;

	private static int activatedHash = Animator.StringToHash ("Activate");

	private Animator anim;
	private Animator transition;
	private GameObject text;
	private GameObject textEnter;

	void Start()
	{
		instance = this;
		anim = GameObject.Find ("Portal_").GetComponent<Animator> ();
		text = GameObject.Find ("Text");
		textEnter = GameObject.Find ("Text_Enter");

		transition = GameObject.Find ("TransitionTemp").GetComponent<Animator>();
	}

	public IEnumerator startTimePortal()
	{
		Destroy(text);
		Destroy(textEnter);

		//GameObject[] allPlayers= GameObject.FindGameObjectsWithTag ("Player");
		//foreach (GameObject player in allPlayers)
		//{
		//	player.rigidbody.velocity = Vector3.zero;
			//player.rigidbody.velocity = new Vector3(x, 0, z).normalized * speed;
		//}

		this.anim.SetTrigger(activatedHash);
		AudioController.instance.Play("026_FusionB");
		LevelFinishedController.instance.setStopped (true);
		yield return new WaitForSeconds(1.5f);
		this.transition.enabled = true;
		yield return new WaitForSeconds(3);
		Application.LoadLevel (1);
	}
}
