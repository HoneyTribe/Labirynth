using UnityEngine;
using System.Collections;

public class SparksController : MonoBehaviour {
	
	public int level;
	
	void Start () 
	{
		gameObject.SetActive(false);
		if (LevelFinishedController.instance.getLevel() == level - 1)
		{
			gameObject.SetActive(true);
		}
	}
}
