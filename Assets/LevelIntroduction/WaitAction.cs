using UnityEngine;
using System.Collections;

public class WaitAction : IntroAction  {
	
	float time;
	
	public WaitAction(float time)
	{
		this.time = time;
	}
	
	public void act()
	{
		if (time > 0)
		{
			time -= Time.deltaTime;
		}
	}

	public bool isFinished()
	{
		return time < 0;
	}
}