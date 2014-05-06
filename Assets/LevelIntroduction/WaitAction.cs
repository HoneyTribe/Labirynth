using UnityEngine;
using System.Collections;

public class WaitAction : Action  {
	
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

	public bool finished()
	{
		return time < 0;
	}
}