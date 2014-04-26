using UnityEngine;
using System.Collections.Generic;
using InControl;

public class InControlManager : MonoBehaviour {

	InputController[] inputs;

	void Start ()
	{
		InputManager.Setup ();
		inputs = gameObject.GetComponents<InputController> ();
	}

	void Update () 
	{
		InputManager.Update ();

		foreach(InputController input in inputs)
		{
			input.React();
		}
	}
}
