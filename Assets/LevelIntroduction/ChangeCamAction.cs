using UnityEngine;
using System.Collections;

public class ChangeCamAction : Action
{
	
	GameObject camera;
	float time = 0;
	float randomNumber;
	
	public ChangeCamAction()
	{
		this.camera = GameObject.Find ("MainCamera_Front");
	}

	public void act()
	{
		time += Time.deltaTime;
		randomNumber = Time.time % 3;
		if(randomNumber >=0 && randomNumber <1)
		{
			this.camera.transform.position = new Vector3(0, 45, 15);
			this.camera.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else if(randomNumber >=1 && randomNumber <2)
		{

			this.camera.transform.position = new Vector3(8, 8, 15);
			this.camera.transform.rotation = Quaternion.Euler(-40, 250, 0);
		}
		else
		{
			this.camera.transform.position = new Vector3(0, 34, -13);
			this.camera.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}

	public bool isFinished()
	{
		if (time > 0.2f) 
		{
			return true;
		}
		else
		{
			return false;
		}
	}

}
