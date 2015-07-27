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

	//private GameObject streamLeft;
	//private GameObject streamRight;
	//private GameObject streamCentre;
	//private ParticleSystem streamLeftP;
	//private ParticleSystem streamRightP;
	//private ParticleSystem streamCentreP;


	void Start()
	{
		instance = this;
		anim = GameObject.Find ("Portal_").GetComponent<Animator> ();
		text = GameObject.Find ("Text");
		textEnter = GameObject.Find ("Text_Enter");

		transition = GameObject.Find ("TransitionTemp").GetComponent<Animator>();

		//streamLeftP = GameObject.Find ("StreamLeft").GetComponent<ParticleSystem>();
		//streamRightP = GameObject.Find ("StreamRight").GetComponent<ParticleSystem>();
		//streamCentreP = GameObject.Find ("StreamCentre").GetComponent<ParticleSystem>();
		//streamLeft = GameObject.Find ("StreamLeft");
		//streamRight = GameObject.Find ("StreamRight");
		//streamCentre = GameObject.Find ("StreamCentre");
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

		GameObject[] allPlayers= GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in allPlayers)
		{
			player.rigidbody.velocity = Vector3.zero;
		}

		LevelFinishedController.instance.PlayerMode();

		this.anim.SetTrigger(activatedHash);
		AudioController.instance.Play("026_FusionC");
		//streamLeftP.Play();
		//streamRightP.Play();
		//streamCentreP.Play();
		LevelFinishedController.instance.setStopped (true);
		yield return new WaitForSeconds(0.5f);
		this.transition.enabled = true;
		yield return new WaitForSeconds(3);
		//streamLeftP.Stop();
		//streamRightP.Stop();
		//streamCentreP.Stop();
		//streamLeftP.Clear();
		//streamRightP.Clear();
		//streamCentreP.Clear();
		//Destroy (streamLeft);
		//Destroy (streamRight);
		//Destroy (streamCentre);
		Application.LoadLevel (1);
	}
}
