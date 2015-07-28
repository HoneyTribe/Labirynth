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
	private float gravity = 1.0f;

	private ParticleSystem galaxy1;
	private ParticleSystem galaxy1_1;
	private ParticleSystem galaxy1_1_1;
	private ParticleSystem galaxy1_2;
	private ParticleSystem galaxy1_3;

	private ParticleSystem galaxy2;
	private ParticleSystem galaxy2_1;
	private ParticleSystem galaxy2_1_1;
	private ParticleSystem galaxy2_2;
	private ParticleSystem galaxy2_3;

	private ParticleSystem galaxy3;
	private ParticleSystem galaxy3_1;
	private ParticleSystem galaxy3_1_1;
	private ParticleSystem galaxy3_2;
	private ParticleSystem galaxy3_3;
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

		galaxy1 = GameObject.Find ("Galaxy1").GetComponent<ParticleSystem>();
		galaxy1_1 = GameObject.Find ("Galaxy1_1").GetComponent<ParticleSystem>();
		galaxy1_1_1 = GameObject.Find ("Galaxy1_1_1").GetComponent<ParticleSystem>();
		galaxy1_2 = GameObject.Find ("Galaxy1_2").GetComponent<ParticleSystem>();
		galaxy1_3 = GameObject.Find ("Galaxy1_3").GetComponent<ParticleSystem>();

		galaxy2 = GameObject.Find ("Galaxy2").GetComponent<ParticleSystem>();
		galaxy2_1 = GameObject.Find ("Galaxy2_1").GetComponent<ParticleSystem>();
		galaxy2_1_1 = GameObject.Find ("Galaxy2_1_1").GetComponent<ParticleSystem>();
		galaxy2_2 = GameObject.Find ("Galaxy2_2").GetComponent<ParticleSystem>();
		galaxy2_3 = GameObject.Find ("Galaxy2_3").GetComponent<ParticleSystem>();

		galaxy3 = GameObject.Find ("Galaxy3").GetComponent<ParticleSystem>();
		galaxy3_1 = GameObject.Find ("Galaxy3_1").GetComponent<ParticleSystem>();
		galaxy3_1_1 = GameObject.Find ("Galaxy3_1_1").GetComponent<ParticleSystem>();
		galaxy3_2 = GameObject.Find ("Galaxy3_2").GetComponent<ParticleSystem>();
		galaxy3_3 = GameObject.Find ("Galaxy3_3").GetComponent<ParticleSystem>();
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
		/*
		 * galaxy1.gravityModifier = gravity;
		galaxy1_1.gravityModifier = gravity;
		galaxy1_1_1.gravityModifier = gravity;
		galaxy1_2.gravityModifier = gravity;
		galaxy1_3.gravityModifier = gravity;

		galaxy2.gravityModifier = gravity;
		galaxy2_1.gravityModifier = gravity;
		galaxy2_1_1.gravityModifier = gravity;
		galaxy2_2.gravityModifier = gravity;
		galaxy2_3.gravityModifier = gravity;

		galaxy3.gravityModifier = gravity;
		galaxy3_1.gravityModifier = gravity;
		galaxy3_1_1.gravityModifier = gravity;
		galaxy3_2.gravityModifier = gravity;
		galaxy3_3.gravityModifier = gravity;
		*/
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
