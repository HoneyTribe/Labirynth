using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour {

	private GameObject gameController;
	private bool opening;
	
	void Start()
	{
		gameController = GameObject.Find ("GameController");
	}

	void Update()
	{
		if (opening)
		{
			transform.Translate (0, 0.1f, 0);
			if (transform.position.y > 15)
			{
				opening = false;
			}
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		ReturnValue foundAllKeys = new ReturnValue ();
		gameController.gameObject.SendMessage ("foundAllKeys", foundAllKeys);
		if (foundAllKeys.value)
		{
			opening = true;
		}
	}
}
