using UnityEngine;
using System.Collections;

public class Blackout : MonoBehaviour {

	public static Blackout instance;

	// Position changed in LevelFinishedController, PlayerSelectionMenu, 

	void Start ()
	{
		instance = this;
	}

}
