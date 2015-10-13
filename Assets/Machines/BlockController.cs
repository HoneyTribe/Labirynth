using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	private const float speed = 10f;

	private Vector3 target;
	private bool moving;

	void Update () {

		if (moving)
		{
			float distance = Vector3.Distance(transform.position, target);
			if (distance > 0)
			{
				transform.position = Vector3.Lerp (
					transform.position, target, Time.deltaTime * speed / distance);
			}
			else
			{
				moving = false;
				AstarPath.active.Scan ();
			}
		}
	}

	public void Move(Vector3 direction)
	{
		Vector3 roundedDirection = new Vector3(Mathf.Round(direction.x),
		                                       Mathf.Round(direction.y),
		            						   Mathf.Round(direction.z));
		if (!moving)
		{
			float x = 0, z = 0;
			if (roundedDirection.x != 0)
			{
				x = Mathf.Sign(roundedDirection.x) * 2 * Instantiation.instance.getSpaceX();
			}
			if (roundedDirection.z != 0)
			{
				z = Mathf.Sign(roundedDirection.z) * 2 * Instantiation.instance.getSpaceZ();
			}

			RaycastHit hit;
			if (Physics.SphereCast(transform.position, 1.2f, roundedDirection, out hit))
			{
				if (((x!=0) && (hit.distance > 2 * Instantiation.instance.getSpaceX())) ||
				    ((z!=0) && (hit.distance > 2 * Instantiation.instance.getSpaceZ())))
				{					
					moving = true;
					target = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
					AudioController.instance.Play("021_BlockMovesB");
				}
			}
		}
	}
}
