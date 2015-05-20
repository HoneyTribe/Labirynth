using UnityEngine;
using System.Collections;

public class MenuLogo : MonoBehaviour {
	
	void Start ()
	{
		if(LevelFinishedController.instance.getMaxLevel()>0)
		{
			this.transform.position = new Vector3(-20f, 0.02f, 1f);
		}
		else
		{
			this.transform.position = new Vector3(2f, 0.02f, 1f);
		}
	}

}
