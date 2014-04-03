using UnityEngine;
using System.Collections;

public class StandardMonsterController : AbstractMonsterController {

	public override void go (ref Vector3 newPosition, bool attractionTrigger) 
	{

		float distance = Vector3.Distance(transform.localPosition, newPosition);

		if ((attractionTrigger) || (distance == 0))
		{
			Vector3 playerPosition = getTarget();
			newPosition = maze.giveMeNextPosition(transform.localPosition, playerPosition);
		}
		else
		{
			transform.position = Vector3.Lerp (
				transform.localPosition, newPosition, Time.deltaTime * speed / distance);
		}
	}

}
