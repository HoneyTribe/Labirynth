using UnityEngine;
using System.Collections;

public class FlyingMonsterController : AbstractMonsterController {

	private static float updateDistance = 5.0f;

	public override void go (ref Vector3 newPosition, bool attractionTrigger) 
	{

		float distance = Vector3.Distance(transform.localPosition, newPosition);

		if ((attractionTrigger) || (distance == 0))
		{
			Vector3 playerPosition = getTarget();
			if (Vector3.Distance(transform.localPosition, playerPosition) > updateDistance)
			{
				Vector3 aaa = new Vector3(playerPosition.x - transform.localPosition.x,
				                          0,
				                          playerPosition.z - transform.localPosition.z);
				Vector3 bbb = aaa.normalized;
				Vector3 ccc = bbb * updateDistance;
				newPosition = transform.localPosition +
							  new Vector3(playerPosition.x - transform.localPosition.x,
				                          0,
				                          playerPosition.z - transform.localPosition.z).normalized * updateDistance;
			}
			else
			{
				newPosition = playerPosition;
			}
		}
		else
		{
			transform.position = Vector3.Lerp (
				transform.localPosition, newPosition, Time.deltaTime * speed / distance);
		}
	}
}
