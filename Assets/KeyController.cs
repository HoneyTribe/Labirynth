using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	private GameObject gameController;
	private bool move = false;
	private Vector3 vectorToTarget;
	private float distanceToTarget;
	private float dist;
	private float distCovered;
	private float fracJourney;
	private float startTime;
	private float speed = 25.0f;
	private GameObject machine;
	private Transform myTransform;
	private bool destroyed = false;
	private float closeDistance = 0.95f;

	void Start()
	{
		gameController = GameObject.Find ("GameController");
		machine = GameObject.Find ("SpaceMachine");
		myTransform = this.transform.parent;
	}

	void Update()
	{
		if(move == true)
		{
			distCovered = (Time.time - startTime) * speed;
			fracJourney = distCovered / distanceToTarget;

			myTransform.position = Vector3.Lerp(myTransform.position, machine.transform.position, fracJourney) ;

			if(fracJourney >= closeDistance && destroyed == false)
			{
				//ScoreController.instance.MinusScore();
				gameController.gameObject.SendMessage("MinusScore");
				destroyed = true;
				Destroy(gameObject.transform.parent.gameObject);
			}
		}
	}
	
	void OnTriggerEnter (Collider currentCollider)
	{
		if ( (currentCollider.tag == "Player") && !currentCollider.gameObject.GetComponent<PlayerController>().isParalysed()  )
		{
			gameController.gameObject.SendMessage("Score");

			vectorToTarget = machine.transform.position - transform.parent.position;
			vectorToTarget.y = 0;
			distanceToTarget = vectorToTarget.magnitude;

			startTime = Time.time;
			move = true;
		}
	}
	
}
